

#include <iostream>
#include <algorithm>

using namespace std;
int main()
{
    setlocale(LC_ALL, "Russian");
    cout << "Введите номер слова" << endl;
    int numW;
    cin >> numW;
    string s = "abcdefghijklmnopqrstuvwxy";
    sort(s.begin(), s.end());
    char m[5][5];
    int curr = 0;
    do
    {
        bool colSorted = false;
        bool rowSorted = false;
        int k = 0;
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
            {
                m[i][j] = s[k];
                k++;
            }

        int x = 0;
        for (int j = 0; j < 5; j++)
        {
            bool colsASC = true;
            for (int i = 0; i < 5 - 1; i++)
            {
                if (m[i + 1][j] <= m[i][j])
                {
                    colsASC = false;
                    break;
                }
            }
            if (colsASC)
                x++;
        }
        if (x == 5)
        {
            colSorted = true;
            //cout << "Все столбцы матрицы упорядочены по росту!" << endl;
        }
        // else cout << "NOOOO" << endl;

        int y = 0;
        for (int i = 0; i < 5; i++)
        {
            bool rowsASC = true;
            for (int j = 0; j < 5 - 1; j++)
            {
                if (m[i][j + 1] <= m[i][j])
                {
                    rowsASC = false;
                    break;
                }
            }
            if (rowsASC)
                y++;
        }
        if (y == 5)
        {
            rowSorted = true;
        }

        if (colSorted == true && rowSorted == true)
            curr++;

    } while (next_permutation(s.begin(), s.end()) && curr != numW);




    for (int i = 0; i < 5; i++) {
        for (int j = 0; j < 5; j++) {
            cout << m[i][j] << " ";
        }
        cout << endl;
    }
    cout << endl;

    string res;
    for (int i = 0; i < 5; i++)
        for (int j = 0; j < 5; j++)
            res += m[i][j];
    cout << res;
}
