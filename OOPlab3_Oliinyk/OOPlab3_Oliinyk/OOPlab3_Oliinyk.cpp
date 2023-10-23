#include <iostream>
#include <string>
#include <vector>
#include <Windows.h>
#include "Bankomat.h"



int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    // Використання конструкторів
    Bankomat atm1; // Використовується конструктор за замовчуванням
    Bankomat atm2("ATM002", 50, 5000); // Використовується конструктор з параметрами
    Bankomat atm3 = atm2; // Використовується конструктор копіювання

    std::vector<int> initialMoney = { 10, 20, 50, 100, 200, 500, 1000 };
    atm1.loadMoney(1000);
    atm2.loadMoney(initialMoney);
    atm3.loadMoney(3000);

    atm1.Display();
    atm2.Display();
    atm3.Display();

    return 0;
}