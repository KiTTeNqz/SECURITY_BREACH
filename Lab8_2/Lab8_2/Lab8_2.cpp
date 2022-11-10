#include <iostream>
#include <vector>
#include <set>
#include <string.h>
#include <string>

using namespace std;

vector<set<int>> firms;
vector<set<int>> conflicts;
vector<vector<pair<int, string>>> subjHist;
vector<vector<pair<int, string>>> objHist;

bool contains(set<int>& s, int elt) {
    return (find(s.begin(), s.end(), elt) != s.end());
}

int getFirm(int obj) {
    for (int i = 0; i < firms.size(); i++) {
        if (contains(firms[i], obj)) {
            return i;
        }
    }
    return -1;
}

int getInterestGroup(int forObject) {
    int firm = getFirm(forObject);

    for (int i = 0; i < conflicts.size(); i++) {
        if (contains(conflicts[i], firm)) {
            return i;
        }
    }

    return -1;
};

bool checkR(int subj_i, int obj_i) {
    int interestGroup = getInterestGroup(obj_i);
    int objFirm = getFirm(obj_i);

    set<int> accessGroups = set<int>();
    set<int> firmGroups = set<int>();

    for (int i = 0; i < subjHist[subj_i].size(); i++) {
        accessGroups.insert(getInterestGroup(subjHist[subj_i][i].first));
        firmGroups.insert(getFirm(subjHist[subj_i][i].first));
    }

    return !contains(accessGroups, interestGroup) || contains(firmGroups, objFirm);
}

void read(int subj_i, int obj_i) {
    if (checkR(subj_i, obj_i)) {
        subjHist[subj_i].push_back(pair<int, string>(obj_i, "r"));
        objHist[obj_i].push_back(pair<int, string>(subj_i, "r"));
        cout << "accepted" << endl;
    }
    else {
        cout << "refused" << endl;
    }
}

bool checkW(int subj_i, int obj_i) {
    int objInter = getInterestGroup(obj_i);
    int objFirm = getFirm(obj_i);
    set<int> readedFirms = set<int>();
    bool readFromEnemy = false;

    for (int i = 0; i < subjHist[subj_i].size(); i++) {
        if (subjHist[subj_i][i].second == "r" &&
            getFirm(subjHist[subj_i][i].first) != objFirm &&
            getInterestGroup(subjHist[subj_i][i].first) == objInter) {
            readFromEnemy = true;
            break;
        }
    }

    return checkR(subj_i, obj_i) && !readFromEnemy;
}

void write(int subj_i, int obj_i) {
    if (checkW(subj_i, obj_i)) {
        subjHist[subj_i].push_back(pair<int, string>(obj_i, "w"));
        objHist[obj_i].push_back(pair<int, string>(subj_i, "w"));
        cout << "accepted" << endl;
    }
    else {
        cout << "refused" << endl;
    }
}

void objInFirm(int firm_i) {
    set<int>::iterator i;
    for (i = firms[firm_i].begin(); i != firms[firm_i].end(); ++i) {
        cout << *i << " ";
    }
    cout << endl;
}

void reportSubj(int subj_i) {
    for (int i = 0; i < subjHist[subj_i].size(); i++) {
        cout << 
            "access " << 
            subjHist[subj_i][i].second << 
            " object " << 
            subjHist[subj_i][i].first << 
            " in firm " << 
            getFirm(subjHist[subj_i][i].first);
    }
}

void reportObj(int obj_i) {
    for (int i = 0; i < objHist[obj_i].size(); i++) {
        cout << 
            "access " << 
            objHist[obj_i][i].second << 
            " object " << 
            objHist[obj_i][i].first << 
            " in firm " << 
            getFirm(objHist[obj_i][i].first);
    }
}


void parseCom(string command) {

    string delimiter = " ";
    size_t pos = 0;
    string temp;
    vector<string> words;

    while ((pos = command.find(delimiter)) != std::string::npos) {
        words.push_back(command.substr(0, pos));
        command.erase(0, pos + delimiter.length());
    }

    words.push_back(command);

    /*for (int i = 0; i < words.size(); i++)
        cout << words[i];*/

    if (words[0] == "start") {
        subjHist = vector<vector<pair<int, string>>>(subjHist.size());
        objHist = vector<vector<pair<int, string>>>(objHist.size());
        cout << "clear" << endl;
    }
    else if (words[0] == "read") {
        int subj_i = stoi(words[1]);
        int obj_i = stoi(words[2]);
        read(subj_i, obj_i);
    }
    else if (words[0] == "write") {
        int subj_i = stoi(words[1]);
        int obj_i = stoi(words[2]);
        write(subj_i, obj_i);
    }
    else if (words[0] == "report_subject") {
        int subj_i = stoi(words[1]);
        reportSubj(subj_i);
    }
    else if (words[0] == "report_object") {
        int obj_i = stoi(words[1]);
        reportObj(obj_i);
    }
    else if (words[0] == "brief_case") {
        int firm_i = stoi(words[1]);
        objInFirm(firm_i);
    }
    else {
        cout << "invalid command" << endl;
    }

    cout << endl;
}

void init(int objCount, int subjCount, int firmCount, int interCount) {
    firms = vector<set<int>>(firmCount, set<int>());
    conflicts = vector<set<int>>(interCount, set<int>());

    subjHist = vector<vector<pair<int, string>>>(subjCount);
    objHist = vector<vector<pair<int, string>>>(objCount);

    firms[0].insert(0);
    firms[1].insert(1);
    firms[1].insert(2);

    firms[2].insert(3);
    firms[2].insert(4);

    conflicts[0].insert(0);
    conflicts[0].insert(1);

    conflicts[1].insert(2);
}


int main() {

    init(5, 1, 3, 2);

    while (true) {
        string s;
        getline(cin, s);
        parseCom(s);
    }

    return 0;
}
