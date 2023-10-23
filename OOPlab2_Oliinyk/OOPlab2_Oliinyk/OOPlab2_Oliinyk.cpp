#include <iostream>
#include <string>
#include <vector>
#include <Windows.h>
#include "Complex.h"



int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Bankomat atm;
    atm.Init("ATM001", 10, 10000);

    std::vector<int> initialMoney = { 10, 20, 50, 100, 200, 500, 1000 };
    for (int money : initialMoney) {
        atm.loadMoney(money);
    }

    std::cout << "Стан банкомату:" << std::endl;
    atm.Display();

    int withdrawalAmount = 350;
    atm.withdrawMoney(withdrawalAmount);

    std::cout << "Після зняття:" << std::endl;
    atm.Display();

    return 0;
}