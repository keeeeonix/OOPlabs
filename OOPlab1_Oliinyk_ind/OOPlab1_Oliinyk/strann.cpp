#include "strann.h"

strann strann::Init(double f, double s)
{
    strann temp;
    temp.first = f;
    temp.second = s;
    return temp;
}

void strann::Read()
{
    cout << "input first" << endl;
    cin >> first;
    cout << "input second" << endl;
    cin >> second;
}

void strann::Display()
{
    cout << "summa = " << first << "\n";
}

strann strann::summa()
{
    strann temp;
    temp.first = (this->first / 22) * this->second;
    return temp;
}
