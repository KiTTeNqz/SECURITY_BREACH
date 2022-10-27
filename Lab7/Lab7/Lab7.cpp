// Lab7.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <regex>
using namespace std;

void cond_a(vector<vector<string>> matrix) {
    vector<int> answer = vector<int>();
    for (int j = 0; j < matrix[0].size(); j++) {
        bool isTrue = true;
        for (int i = 0; i < matrix.size(); i++) {
            if (matrix[i][j] != "_")
                isTrue = false;
        }
        if (isTrue) answer.push_back(j + 1);
    }

    if (answer.size() != 0) {
        cout << "Cписок объектов, не доступных для всех субъектов" << endl;
        for (int i = 0; i < answer.size(); i++)
            cout << answer[i] << " ";
        cout << endl;
    }
    else
        cout << "Нет строк, удовлетворяющих условию A" << endl;
}

void cond_b(vector<vector<string>> matrix) {
    vector<int> answer = vector<int>();
    for (int i = 0; i < matrix.size(); i++) {
        bool isTrue = true;
        for (int j = 0; j < matrix[i].size(); j++) {
            if (matrix[i][j] != "_")
                isTrue = false;
        }
        if (isTrue) answer.push_back(i + 1);
    }

    if (answer.size() != 0) {
        cout << "Cписок субъектов, не доступных для всех объектов" << endl;
        for (int i = 0; i < answer.size(); i++)
            cout << answer[i] << " ";
        cout << endl;
    }
    else
        cout << "Нет строк, удовлетворяющих условию B" << endl;
}

void cond_c(vector<vector<string>> matrix) {
    vector<int> answer = vector<int>();
    for (int i = 0; i < matrix.size(); i++) {
        bool isTrue = true;
        for (int j = 0; j < matrix[i].size(); j++) {
            if (matrix[i][j] != "RW")
                isTrue = false;
        }
        if (isTrue) answer.push_back(i + 1);
    }

    if (answer.size() != 0) {
        cout << "Cубъекты у которых есть полный доступ" << endl;
        for (int i = 0; i < answer.size(); i++)
            cout << answer[i] << " ";
        cout << endl;
    }
    else
        cout << "Нет строк, удовлетворяющих условию C"<<endl;
}

void cond_d(vector<vector<string>> matrix) {
    vector<int> answer = vector<int>();
    for (int i = 0; i < matrix.size(); i++) {
        bool isTrue = true;
        for (int j = 0; j < matrix[i].size(); j++) {
            if (matrix[i][j] != "RW" && matrix[i][j] != "W")
                isTrue = false;
        }
        if (isTrue) answer.push_back(i + 1);
    }

    if (answer.size() != 0) {
        cout << "Cписок субъектов C1 C2 .. C_i имеющих право записи в один объект O_j." << endl;
        for (int i = 0; i < answer.size(); i++)
            cout << answer[i] << " ";
        cout << endl;
    }
    else
        cout << "Нет строк, удовлетворяющих условию D" << endl;
}

void cond_e(vector < vector <string> > matrix)
{
    vector <int> answer = vector <int>();
    for (int i = 0; i < matrix.size(); i++) 
    {
        int RW = 0, W = 0;
        for (int j = 0; j < matrix[0].size(); j++) 
        {
            if (matrix[i][j] == "RW")
                RW++;
            if (matrix[i][j] == "W")
                W++;
        }
        if (RW == 1 && W == 0)
            answer.push_back(i + 1);
    }
    if (answer.size() != 0) {
        cout << "Cписок субъектов, каждый из которых имеет полный доступ только к одному объекту" << endl;
        for (int i = 0; i < answer.size(); i++)
            cout << answer[i] << " ";
        cout << endl;
    }
    else
        cout << "Нет строк, удовлетворяющих условию Е" << endl;
}

vector <vector<string>> input()
{
    int n, m;
    vector <string> lines;
    
    string s;
    ifstream environ_file("access_matr.txt");
    while (getline(environ_file, s))
        lines.push_back(s);
    environ_file.close();
    n = stoi(lines[0]);
    m = stoi(lines[1]);
    lines.erase(lines.begin(), lines.begin() + 2);
    vector < vector <string> > matrix = vector < vector <string> >();
    string text = "";
    regex re("[ ]");
    vector<string> words{};
    string space_delimiter = " ";
    for (int i = 0; i < n; i++) // субъекты
    {
        //size_t pos = 0;
        //matrix.push_back(vector<string>());
        //text = lines[i];
        //while ((pos = text.find(space_delimiter)) != string::npos) {
        //    words.push_back(text.substr(0, pos));
        //    text.erase(0, pos + space_delimiter.length());
        //}
        //for (int j = 0; j < m; j++) // объекты
        //    matrix[i].push_back(words[j]);

        matrix.push_back(vector<string>());
        text = lines[i];
        sregex_token_iterator first{ text.begin(), text.end(), re, -1 }, last;
        vector<string> tokens{ first, last };
        for (int j = 0; j < m; j++) // объекты
            matrix[i].push_back(tokens[j]);

    }
    return matrix;
}


int main()
{
    vector<vector<string>> matrix = input();
    setlocale(LC_ALL, "RUS");
    ofstream fout;
    fout.open("output.txt");
    if (fout.is_open())
    {
        fout << matrix.size() << endl;
        fout << matrix[0].size() << endl;
        for (int i = 0; i < matrix.size(); i++)
        {
            for (int j = 0; j < matrix[i].size(); j++)
            {
                fout << matrix[i][j] << " ";
                cout << matrix[i][j] << " ";
            }
            fout << endl;
            cout << endl;
        }
    }
    fout.close();

    cond_a(matrix);
    cond_b(matrix);
    cond_c(matrix);
    cond_d(matrix);
    cond_e(matrix);
}

