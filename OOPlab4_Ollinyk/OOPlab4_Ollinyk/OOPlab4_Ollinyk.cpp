#include <iostream>
#include <string>
#include <vector>
#include <Windows.h>
#include "Bankomat.h"



int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Bankomat atm1("ATM001", 10, 10000);
    Bankomat atm2("ATM002", 50, 5000);
    Bankomat atm3 = atm2;

    atm1.loadMoney(1000);
    std::vector<int> initialMoney = { 10, 20, 50, 100, 200, 500, 1000 };
    atm2.loadMoney(initialMoney);
    atm3.loadMoney(3000);

    std::cout << "ÀÒÌ 1:\n" << atm1 << std::endl;
    std::cout << "ÀÒÌ 2:\n" << atm2 << std::endl;
    std::cout << "ÀÒÌ 3:\n" << atm3 << std::endl;

    if (atm1 == atm2) {
        std::cout << "ÀÒÌ 1 òà ÀÒÌ 2 îäíàêîâ³.\n";
    }
    else {
        std::cout << "ÀÒÌ 1 òà ÀÒÌ 2 ð³çí³.\n";
    }

    Bankomat combinedATM = atm1 + atm2;
    std::cout << "Ïîºäíàíèé ÀÒÌ:\n" << combinedATM << std::endl;

    return 0;
}