#include <iostream>
#include <vector>
#include <time.h>
#include <cmath>
using namespace std;



vector<long long int> primes = {
       503, 509, 521, 523, 541, 547, 557, 563, 569, 571,
       577, 587, 593, 599, 601, 607, 613, 617, 619, 631,
       641, 643, 647, 653, 659, 661, 673, 677, 683, 691,
       701, 709, 719, 727, 733, 739, 743, 751, 757, 761,
       769, 773, 787, 797, 809, 811, 821, 823, 827, 829,
       839, 853, 857, 859, 863, 877, 881, 883, 887, 907,
       911, 919, 929, 937, 941, 947, 953, 967, 971, 977,
       983, 991, 997
};

void restorePrime() {
    primes = {
       503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 
       577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 
       641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 
       701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 
       769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 
       839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 
       911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 
       983, 991, 997
    };
}

long long int getPrime() {
    srand(time(NULL));
    int idx = rand() % primes.size();
    long long int prime = primes[idx];
    primes.erase(primes.begin() + idx);
    return prime;
}

long long int power(long long int a, long long int b, long long int c) {
    long long int x = 1;
    long long int y = a;
    long long int doubleY = 0;
    while (b > 0) {
        if (b % 2 != 0) {
            x = (x * y) % c;
        }
        doubleY = y * y;
        y = doubleY % c;
        b = long long int(b / 2);
    }
    return x % c;
}

long long int gcdExtended(long long int a, long long int b, long long int* x, long long int* y);

long long int modinv(long long int A, long long int M){
    long long int x, y;
    long long int g = gcdExtended(A, M, &x, &y);
    if (g != 1)
        return 0;
    else {

        long long int res = (x % M + M) % M;
        return res;
    }
}

long long int gcdExtended(long long int a, long long int b, long long int* x, long long int* y){

    if (a == 0) {
        *x = 0, * y = 1;
        return b;
    }

    long long int x1, y1;
    long long int gcd = gcdExtended(b % a, a, &x1, &y1);

    *x = y1 - (b / a) * x1;
    *y = x1;

    return gcd;
}

vector<long long int> getNs(int count) {
    vector<long long int> nS;
    long long int p;
    long long int q;
    long long int n;
    for (int i = 0; i < count; i++) {
        p = getPrime();
        q = getPrime();
        n = p * q;
        nS.push_back(n);
    }
    return nS;
}

vector<long long int> getCs(int m, int e, vector<long long int> nS, int count) {
    vector<long long int> cS;
    long long int powerVal;
    for (int i = 0; i < count; i++) {
        powerVal = power(m, e, nS[i]);
        cS.push_back(powerVal);
    }
    return cS;
}

long long int solveCRT(vector<long long int> nS, vector<long long int> cS){
    long long int x = 0;
    long long int N = 1;
    for (int i = 0; i < nS.size(); i++) {
        N *= nS[i];
    }
    vector<long long int> tmpNs;
    for (int i = 0; i < nS.size(); i++) {
        tmpNs.push_back(N / nS[i]);
    }

    vector<long long int> dS;
    for (int i = 0; i < nS.size(); i++) {
        dS.push_back(modinv(tmpNs[i], nS[i]));
    }

    for (int i = 0; i < nS.size(); i++) {
        x += cS[i] * tmpNs[i] * dS[i];
    }

    long long int preAns = x % N;
    long long int ans = ceil(pow(preAns, 1.0 / double(nS.size())));

    return ans;
}

int main()
{
    setlocale(LC_ALL, "Rus");
    //(87, 3), (115, 3), (187, 3) //10-120
    //(67, 3), (101, 3), (137, 3) //10
    //(87, 4), (101,4) (115, 4), (187, 4) //10-100

    long long int m = 89;
    //char m = 'b';
    cout << "Изначальное сообщение : " << m << endl;
    cout << endl;

    long long int e = 3;
    //long long int e = 4;
    cout << "Параметр е: " << e << endl;
    cout << endl;
    int msgCount = 3;
    //int msgCount = 4;

    
    //vector<long long int> nS = {87, 101, 115, 187};
    //vector<long long int> nS = {87, 115, 187};
    vector<long long int> nS = {67, 101, 137};

    //vector<long long int> nS = getNs(msgCount);
  
    vector<long long int> cS = getCs(m, e, nS, msgCount);

    cout << "nS: ";
    for (int i = 0; i < nS.size(); i++)
        cout << nS[i]<<" ";
    cout << endl;
    cout << endl;

    cout << "cS: ";
    for (int i = 0; i < cS.size(); i++)
        cout << cS[i]<<" ";
    cout << endl;
    cout << endl;

    long long int mAns = solveCRT(nS, cS);
    //char m2 = mAns;
    cout <<"Перехваченное сообщение: " << mAns;
    cout << endl;
    
}

