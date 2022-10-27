#include <iostream>
#include <vector>

using namespace std;
struct Cell {
	int subj;
	int obj;
	string rights;
};

string RW_gen()
{
	string M[2] = { "R","W" };
	int w = 2;
	int i, j, n;
	string buff;
	n = pow(2, w);
	vector <string> RWOX;
	for (int i = 0; i < n; i++)
	{
		for (j = 0; j < w; j++)
			if (i & (1 << j))
				buff += M[j];
		RWOX.push_back(buff);
		buff = "";
	}
	int random = rand() % 3 + 1;
	int isNotEmp = rand() % 2;
	string for_return;
	if (isNotEmp == 1)
		for_return = RWOX[random];
	else
		for_return = "_";
	return for_return;
}

void output(vector <Cell> Cells)
{
	cout << "========================================" << endl;
	cout << "Имя субъекта, имя объекта, права доступа" << endl;
	cout << "" << endl;
	for (int i = 0; i < Cells.size(); i++)
	{
		cout << Cells[i].subj << "\t" << Cells[i].obj << "\t" << Cells[i].rights << endl;
		cout << "==================" << endl;
	}
	cout << "========================================" << endl;
}
void clear(vector <Cell>& Cells)
{
	for (int i = 0; i < Cells.size(); i++)
	{
		if (Cells[i].rights == "")
		{
			Cells.erase(Cells.begin() + i);
		}
	}
}

void update(vector <Cell>& Cells, int add_or_del, int i, int j, string rule)
{
	for (int d = 0; d < Cells.size(); d++)
	{
		if (Cells[d].subj == i && Cells[d].obj==j && Cells[d].rights=="" && add_or_del == 2)
		{
			Cell temp;
			temp.subj = i;
			temp.obj = j;
			temp.rights = rule;
			Cells.push_back(temp);
		}

		else if (Cells[d].subj == i && Cells[d].obj == j && add_or_del == 1)
		{
			string res = rule;
			Cells[d].rights.erase(Cells[d].rights.find(rule), 1);
		}
		else if (Cells[d].subj == i && Cells[d].obj == j && add_or_del == 2)
		{
			 string res = rule;
			
			 size_t found = Cells[d].rights.find(rule);
			 if (found==string::npos)
			 {
				 Cells[d].rights += rule;
			 }
		}
	}
	clear(Cells);
	output(Cells);
}

void insert_new_subj(vector <Cell>& Cells, int new_subj_i, int obj_count)
{
	Cell newCell;
	newCell.subj = new_subj_i;
	newCell.rights = "R";
	for (int i = 0; i < obj_count; i++)
	{
		newCell.obj = i;
		Cells.push_back(newCell);
	}
	clear(Cells);
	output(Cells);
}

void delete_subj(vector <Cell>& Cells, int del_subj, int obj_count)
{
	bool finded = false;
	for (int i = 0; i < Cells.size(); i++)
	{
		if (Cells[i].subj == del_subj)
		{
			finded = true;
			Cells.erase(Cells.begin() + i);
		}
	}
	if (!finded)
		cout << "Ни одного субъекта с таким именем не найдено, удаления не произошло" << endl;
	if (finded)
	{
		clear(Cells);
		output(Cells);
	}

}

void usage_prc(vector <Cell>& Cells, int obj_count)
{
	int max_index_i = -1;
	for (int i = 0; i < Cells.size(); i++)
		if (Cells[i].subj > max_index_i)
			max_index_i = Cells[i].subj;
	max_index_i++;
	float all = max_index_i * obj_count;
	float items_size = Cells.size();
	cout << "Заполненность матрицы :" << float((items_size / all) * 100) << "%" << endl;
}
void list_for_t(vector <Cell>& Items, int obj_index, int obj_count)
{
	vector <int> answer = vector <int>();
	for (int i = 0; i < Items.size(); i++)
	{
		if (!(find(answer.begin(), answer.end(), Items[i].subj) != answer.end()) && Items[i].obj == obj_index)
			answer.push_back(Items[i].subj);
	}
	cout << "Вывод списка субъектов с доступом к объекту T" << endl;
	for (int i = 0; i < answer.size(); i++)
	{
		cout << answer[i] << endl;
	}
}
int main()
{
	setlocale(LC_ALL, "RUS");
	srand(time(0));
	int n = 5;
	int m = 6;
	vector <Cell> Items = vector <Cell>();

	cout << "Генерация" << endl;
	for (int i = 0; i < n; i++) // строки-субъекты
	{
		for (int j = 0; j < m; j++) // столбцы-объекты
		{
			string matrix = RW_gen();
			if (matrix != "_")
			{
				Cell temp_item;
				temp_item.subj = i;
				temp_item.obj = j;
				temp_item.rights = matrix;
				Items.push_back(temp_item);
			}
		}
	}
	output(Items);

	cout << "Начало работы." << endl;
	cout << "Окончание работы -  0" << endl;
	cout << "1 - редактирование ячейки" << endl;
	cout << "2 - Добавление нового субъекта с указанием его номера" << endl;
	cout << "3 - Удаление субъекта из матрицы" << endl;
	cout << "4 - Вычисление процента заполненности матрицы" << endl;
	cout << "5 - Формирование списка субъектов, имеющих доступ к указанному объекту" << endl;

	int Inp;
	do
	{
		cout << "Введите команду: ";
		cin >> Inp;
		string rule;
		switch (Inp) {
		case 0:
			cout << "Выход" << endl;
		case 1:
			cout << "редактирование ячейки" << endl;
			int add_or_del, i, j;
			cout << "Удаление права - 1, Добавление права - 2" << endl;
			cin >> add_or_del;
			cout << "Введите право, номер субъекта, номер объекта" << endl;
			cin >> rule >> i >> j;
			if (i > n || j > m)
			{
				cout << "Не выполнено, такого объекта нет" << endl;
			}
			else
			{
				cout << "Выполняется" << endl;
				update(Items, add_or_del, i, j, rule);
			}
			break;

		case 2:
			cout << "Добавление субъекта" << endl;
			int new_subj_i;
			cout << "Введите числовой индекс(имя) нового субъекта" << endl;
			cin >> new_subj_i;
			cout << "Выполняется" << endl;
			insert_new_subj(Items, new_subj_i, m);
			break;
		case 3:
			cout << "Удаление субъекта" << endl;
			int del_subj_i;
			cout << "Введите числовой индекс(имя) удаляемого субъекта" << endl;
			cin >> del_subj_i;
			cout << "Выполняется" << endl;
			delete_subj(Items, del_subj_i, m);
			break;
		case 4:
			cout << "Вычисление заполненности матрицы" << endl;
			cout << "Выполняется" << endl;
			usage_prc(Items, m);
			break;
		case 5:
			cout << "Список субъектов с доступом к объекту T" << endl;
			cout << "Введите числовой индекс объекта T" << endl;
			int obj_m;
			cin >> obj_m;
			cout << "Выполняется" << endl;
			list_for_t(Items, obj_m, m);
			break;
		default:
			cout << "ТАКОЙ КОМАНДЫ НЕТ!!!" << endl;
			break;
		}
	} while (Inp != 0);
}