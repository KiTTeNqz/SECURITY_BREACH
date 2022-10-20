#include <iostream>
#include <vector>
#include <string>
#include <ctime>
using namespace std;

string generate() // рандоматор прав доступа на чтение и запись
{
	int a = rand() % 2;
	if (a == 1)
		return "W";
	if (a == 2)
		return "R";
	else return "RW";
}

bool check(int n, int m, int* ls, int* lo, vector<vector<string>> matrix) {
	for (int i = 0; i < n; i++)
		for (int j = 0; j < m; j++)
			if (
				(ls[i] > lo[j] && matrix[i][j] == "W") ||
				(ls[i] < lo[j] && matrix[i][j] == "R") || 
				(ls[i] != lo[j] && matrix[i][j] == "RW")
				) {
				//cout << "ERROR. SUBJECT " << ls[i] << " TRYING TO " << matrix[i][j] << " OBJECT " << lo[i] << endl;
				return false;
			}
				
	return true;
}

bool nextSet(int* a, int n, int m)
{
	int j = m - 1;
	while (j >= 0 && a[j] == n) j--;
	if (j < 0) return false;
	if (a[j] >= n)
		j--;
	a[j]++;
	if (j == m - 1) return true;
	for (int k = j + 1; k < m; k++)
		a[k] = 1;
	return true;
}

vector<int> arrToVec(int* a, int n) {
	vector<int> result(n);
	for (int i = 0; i < n; i++)
		result[i] = a[i];
	return result;
}

void Print(int* a, int n)
{
	static int num = 1;
	cout << num++ << ":  ";
	for (int i = 0; i < n; i++)
		cout << a[i] << " ";
	cout << endl;
}

int main() {
	setlocale(LC_ALL, "RUS");
	int n, m, k;
	cout << "Введите число субъектов и объектов " << endl;
	cin >> n >> m;
	cout << "Введите количество уровней доступа " << endl;
	cin >> k;

	int* lo = new int[m];
	int* ls = new int[n];
	for (int i = 0; i < m; i++) {
		lo[i] = 1;
	}
	for (int i = 0; i < n; i++) {
		ls[i] = 1;
	}
	vector <vector<string>> RW(n, vector <string>(m));; 
	srand(time(0));
	cout << "Генерация RW" << endl;
	for (int i = 0; i < n; i++)
		for (int j = 0; j < m; j++)
		{
			RW[i][j] = generate();
		}
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++)
		{
			cout << RW[i][j]<<" ";
		}
		cout << endl;
	}
	vector<int> loOut;
	vector<int> lsOut;
	bool flag = false;
	do {
		//cout << "object: ";
		//Print(lo, m);

		for (int i = 0; i < n; i++) {
			ls[i] = 1;
		}

		do {
			//cout << "subject: ";
			//Print(ls, n);
			flag = check(n, m, ls, lo, RW);
			if (flag) {
				loOut = arrToVec(lo, m);
				lsOut = arrToVec(ls, n);
			}
		} while (nextSet(ls, k, n)&&!flag);
	} while (nextSet(lo, k, m)&&!flag);

	if (flag) {
		cout << "Субъекты: ";
		for (int i = 0; i < n; i++)
			cout << lsOut[i];
		cout << endl;

		cout << "Объекты: ";
		for (int i = 0; i < m; i++)
			cout << loOut[i];
		cout << endl;
	}
	else {
		cout << "Невозможно сгенерировать!";
	}
	cin.get(); cin.get();
}
