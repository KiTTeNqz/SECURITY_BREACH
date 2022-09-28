// Lab3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <fstream>
using namespace std;

bool isPrime(int a) {
    if (a <= 1)
        return false;
    if (a == 2 || a == 3)
        return true;
    else
        for (int i = 2; i < a; i++)
            if (a % i == 0)
                return false;
    return true;

}

string code(string encoded) {
    string a;
    string first;
    string second;
    for (int i = 0; i < encoded.length(); i++) {
        if (isPrime(i + 1))
            first = first + encoded[i];
            
        else second = second + encoded[i];
    }
    return first+second;
}

string decode(string encoded) {
    char* arr = new char[encoded.length()+1];
    arr[encoded.length()] = '\0';
    int j = 0;
    bool* used = new bool[encoded.length()];
    for (int i = 0; i < encoded.length(); i++){
        used[i] = false;
    }
    for(int i=0; i < encoded.length(); i++)
        if (isPrime(i + 1)) {
            arr[i] = encoded[j];
            used[i] = true;
            j++;
        }
    for (int i = 0; i < encoded.length(); i++)
        if (!used[i]) {
            arr[i] = encoded[j];
            j++;
        }
    string str(arr);
    return str;
}

int main()
{
    /*
    string input = "abcdefgh";
    string str = code(input);
    cout << str<<endl ;
    string coded = "BAAAACB";
    string decoded = decode(coded);
    cout << decoded << endl;
    */
    ifstream fin = ifstream("input.txt");
    ofstream fout = ofstream("output.txt");
    int k = 0;
    string str;
    fin >> k;
    fin >> str;

    for (int i = 1; i <= k; i++) {
        str = decode(str);
    }

    fout << str;
    fin.close();
    fout.close();
}
