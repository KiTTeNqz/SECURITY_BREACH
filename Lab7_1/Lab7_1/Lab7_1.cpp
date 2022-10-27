#include <iostream>
#include <vector>
#include <algorithm>
#include <fstream>
#include <string>
#include <ctime>
#include <regex>
using namespace std;


string rwoxGen()
{
	string M = "RWOX";


	int n = pow(2, M.size());
	static vector <string> fullRuleSet;

	if (fullRuleSet.size() == 0) {
		for (int i = 0; i < n; i++) {
			string buff = "";
			for (int j = 0; j < M.size(); j++) {
				if (i & (1 << j)) {
					buff += M[j];
				}
			}
			fullRuleSet.push_back(buff);
		}
	}
	string ruleSet = fullRuleSet[rand() % 15 + 1];
	return ruleSet;
}

string split(string input, regex re) {
	string res = "";
	sregex_token_iterator first{ input.begin(), input.end(), re, -1 }, last;
	vector<string> tokens{ first, last };
	for (int i = 0; i < tokens.size(); i++)
		res += tokens[i];
	return res;
}

string commandGen(int n, int m)
{
	int Sub_n = n;
	int Obj_m = m;

	string commandString = "";
	string ruleSet = "RWOX";

	int cmd1 = rand() % 6 + 0;
	string commandSet[6] =
	{
		"cco = 'O+' image_",
		"ccs = 'S+' image_",
		"cdo = 'O-' image_",
		"cds = 'S-' image_",
		"cer = ",
		"cdr = "
	};

	if (cmd1 == 0) {
		commandString += commandSet[cmd1];
		int rander = rand() % Obj_m + 1;
		commandString += to_string(rander);
	}
	if (cmd1 == 1) {
		commandString += commandSet[cmd1];
		int rander = rand() % Sub_n + 1;
		commandString += to_string(rander);
	}
	if (cmd1 == 2) {
		commandString += commandSet[cmd1];
		int rander = rand() % Obj_m + 1;
		commandString += to_string(rander);
	}
	if (cmd1 == 3) {
		//N - строка
		commandString += commandSet[cmd1];
		int rander = rand() % Sub_n + 1;
		commandString += to_string(rander);
	}
	if (cmd1 == 4) {
		commandString += commandSet[cmd1];
		int RWOX_rnd = rand() % 3;

		int randN = rand() % Sub_n + 1;
		int randM = rand() % Obj_m + 1;

		commandString += "'";
		commandString += ruleSet[RWOX_rnd];
		commandString += "'";
		commandString += " image_";
		commandString += to_string(randN);
		commandString += " image_";
		commandString += to_string(randM);
	}
	if (cmd1 == 5) {
		commandString += commandSet[cmd1];
		int RWOX_rnd = rand() % 3;

		int randN = rand() % Sub_n + 1;
		int randM = rand() % Obj_m + 1;

		commandString += "'";
		commandString += ruleSet[RWOX_rnd];
		commandString += "'";
		commandString += " image_";
		commandString += to_string(randN);
		commandString += " image_";
		commandString += to_string(randM);
	}
	return commandString;
}

void writeGen(int count, int n, int m)
{
	ofstream output_prgrm;
	output_prgrm.open("prgrm.txt");
	if (output_prgrm.is_open())
	{
		for (int i = 0; i < count; i++)
		{
			output_prgrm << commandGen(n, m) << endl;
		}
	}
	output_prgrm.close();
}

void interpreter()
{
	int n, m;
	vector <string> lines;

	string s;
	ifstream environ_file("environ.txt");
	while (getline(environ_file, s))
	{
		lines.push_back(s);
	}
	environ_file.close();

	n = stoi(lines[0]);
	m = stoi(lines[1]);

	lines.erase(lines.begin(), lines.begin() + 2);

	vector < vector <string> > matrix = vector < vector <string> >();
	string input = "";
	regex re("[ ]");

	for (int i = 0; i < n; i++) // субъекты
	{
		matrix.push_back(vector<string>());
		input = lines[i];
		sregex_token_iterator first{ input.begin(), input.end(), re, -1 }, last;
		vector<string> tokens{ first, last };
		for (int j = 0; j < m; j++) // объекты
		{
			matrix[i].push_back(tokens[j]);
		}
	}

	cout << "вывод для теста matrix" << endl;

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
			cout << matrix[i][j] << ' ';
		cout << endl;
	}

	vector <string> temp_prgrm;

	string s2;
	ifstream prgrm_file("prgrm.txt");
	while (getline(prgrm_file, s))
	{
		temp_prgrm.push_back(s);
	}
	prgrm_file.close();

	int cmd_K = temp_prgrm.size();



	for (int i = 0; i < cmd_K; i++)
	{
		cout << temp_prgrm[i] << endl;
	}

	string input2;
	regex re2(" image_");

	vector < vector <string> > structed_CMD(cmd_K, vector <string>());

	for (int i = 0; i < cmd_K; i++)
	{
		input2 = temp_prgrm[i];
		sregex_token_iterator first{ input2.begin(), input2.end(), re2, -1 }, last;
		vector<string> tokens{ first, last };
		int k = tokens.size();
		structed_CMD[i].resize(k);
		for (int j = 0; j < k; j++)
		{
			structed_CMD[i][j] = tokens[j];
		}
	}

	for (int i = 0; i < cmd_K; i++)
	{
		if (structed_CMD[i][0].find("cco") != string::npos)
		{
			cout << i << " " << "cco" << endl;
			int ind = stoi(structed_CMD[i][1]);
			ind--;
			if (!(matrix.size() == 0 || matrix[0].size() == 0))
			{
				if (matrix[0].size() >= ind) {
					for (int j = 0; j < matrix.size(); j++)
					{
						matrix[j].insert(matrix[j].begin() + ind, "R");
					}
				}
				else {
					for (int j = 0; j < matrix.size(); j++)
					{
						matrix[j].push_back("R");
					}
				}
			}
			else {
				cout << "выполнить команду невозможно, команда -" << structed_CMD[i][0] << endl;
			}
		}

		if (structed_CMD[i][0].find("ccs") != string::npos)
		{
			cout << i << " " << "ccs" << endl;
			int ind = stoi(structed_CMD[i][1]);
			ind--;
			vector <string> row = vector <string>(matrix[0].size(), "R");
			if (!(matrix.size() == 0 || matrix[0].size() == 0))
			{
				if (ind <= matrix.size())
					matrix.insert(matrix.begin() + ind, row);
				else
					matrix.push_back(row);
			}
			else {
				cout << "выполнить команду невозможно, команда -" << structed_CMD[i][0] << endl;
			}
		}

		if (structed_CMD[i][0].find("cdo") != string::npos)
		{
			cout << i << " " << "cdo" << endl;
			int ind = stoi(structed_CMD[i][1]);
			ind--;

			if (!(matrix.size() == 0 || matrix[0].size() <= ind))
			{
				for (int j = 0; j < matrix.size(); j++)
				{
					matrix[j].erase(matrix[j].begin() + ind);
				}
			}
			else {
				cout << "выполнить команду невозможно, команда -" << structed_CMD[i][0] << endl;
			}
		}

		if (structed_CMD[i][0].find("cds") != string::npos)
		{
			cout << i << " " << "cds" << endl;
			int ind = stoi(structed_CMD[i][1]);
			ind--;
			if (!(matrix.size() == 0 || matrix.size() <= ind))
			{
				matrix.erase(matrix.begin() + ind);
			}
			else {
				cout << "выполнить команду невозможно, команда -" << structed_CMD[i][0] << endl;
			}
		}

		if (structed_CMD[i][0].find("cer") != string::npos)
		{
			cout << i << " " << "cer" << endl;
			int ind_S = stoi(structed_CMD[i][1]);
			int ind_O = stoi(structed_CMD[i][2]);
			ind_S--; ind_O--;

			if (!(matrix.size() == 0 || matrix.size() <= ind_S || matrix[0].size() <= ind_O))
			{
				string input2 = structed_CMD[i][0];
				regex re2("cer = ");
				string temp = split(input2, re2);

				regex re("'");

				string res = split(temp, re);

				for (int inputInd = 0; inputInd < res.size(); inputInd++)
				{
					bool f = true;
					for (int nowInd = 0; nowInd < matrix[ind_S][ind_O].size(); nowInd++)
					{
						if (res[inputInd] == matrix[ind_S][ind_O][nowInd])
						{
							f = false;
							break;
						}
					}
					if (f)
					{
						matrix[ind_S][ind_O] += res[inputInd];
					}
				}


			}
		}

		if (structed_CMD[i][0].find("cdr") != string::npos)
		{
			cout << i << " " << "cdr" << endl;
			int ind_S = stoi(structed_CMD[i][1]);
			int ind_O = stoi(structed_CMD[i][2]);
			ind_S--; ind_O--;
			if (!(matrix.size() == 0 || matrix.size() <= ind_S || matrix[0].size() <= ind_O))
			{

				string input2 = structed_CMD[i][0];
				regex re2("cdr = ");

				string temp = split(input2, re2);

				regex re("'");
				string res = split(temp, re);;
				for (int inputInd = 0; inputInd < res.size(); inputInd++)
				{
					for (int nowInd = 0; nowInd < matrix[ind_S][ind_O].size(); nowInd++)
					{
						if (res[inputInd] == matrix[ind_S][ind_O][nowInd])
						{
							matrix[ind_S][ind_O] = matrix[ind_S][ind_O].substr(0, nowInd) + matrix[ind_S][ind_O].substr(nowInd + 1, matrix[ind_S][ind_O].size() - nowInd - 1);
							break;
						}
					}
				}

			}
		}
	}
	ofstream fout;
	fout.open("output.txt");
	if (fout.is_open())
	{
		for (int i = 0; i < matrix.size(); i++)
		{
			for (int j = 0; j < matrix[i].size(); j++)
				fout << matrix[i][j] << ' ';
			fout << endl;
		}
	}
	fout.close();
}

void main()
{
	setlocale(LC_ALL, "RUS");
	srand(time(0));
	int n;
	int m; 
	int k; 
	n = rand() % 10 + 1;
	m = rand() % 10 + 1;
	k = rand() % 10 + 5;
	vector < vector <string> > RW(n, vector <string>(m));
	vector <int> LS(n);
	vector <int> LO(m); 
	cout << "генерация rw" << endl;
	for (int i = 0; i < n; i++)
		for (int j = 0; j < m; j++)
			RW[i][j] = rwoxGen();
	ofstream output_environ;
	output_environ.open("environ.txt");
	if (output_environ.is_open())
	{
		output_environ << n << endl;
		output_environ << m << endl;
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				output_environ << RW[i][j] << " ";
			}

			output_environ << endl;
		}
	}
	output_environ.close();
	writeGen(k, n, m);
	interpreter();
}
