#pragma once
#include <iostream>
#include <string>
#include <vector>

class Bankomat {
private:
    std::string atmID;
    int currentBalance;
    int minWithdrawal;
    int maxWithdrawal;
    std::vector<int> denominations;  // Поле для зберігання номіналів купюр

public:
    Bankomat() {
        // Конструктор за замовчуванням
    }

    void Init(std::string id, int minWithdrawal, int maxWithdrawal) {
        atmID = id;
        this->minWithdrawal = minWithdrawal;
        this->maxWithdrawal = maxWithdrawal;
        currentBalance = 0;
        denominations = { 10, 20, 50, 100, 200, 500, 1000 };
    }

    void Read() {
        std::cout << "Введіть суму для завантаження в банкомат: ";
        int amount;
        std::cin >> amount;
        loadMoney(amount);
    }

    void Display() {
        std::cout << "ID банкомату: " << atmID << std::endl;
        std::cout << "Мінімальна сума для зняття: " << minWithdrawal << " гривень" << std::endl;
        std::cout << "Максимальна сума для зняття: " << maxWithdrawal << " гривень" << std::endl;
        std::cout << "Залишок в банкоматі: " << currentBalance << " гривень" << std::endl;
    }

    // Метод для завантаження купюр у банкомат
    void loadMoney(int amount) {
        currentBalance += amount;
    }

    // Метод для зняття грошей з банкомату
    bool withdrawMoney(int amount) {
        if (amount < minWithdrawal || amount > maxWithdrawal) {
            std::cout << "Неприпустима сума для зняття грошей." << std::endl;
            return false;
        }

        if (amount > currentBalance) {
            std::cout << "Недостатньо грошей в банкоматі." << std::endl;
            return false;
        }

        // Перевірка на доступність номіналів купюр для видачі
        int remainingAmount = amount;
        std::vector<int> usedDenominations;

        for (int i = denominations.size() - 1; i >= 0; i--) {
            while (remainingAmount >= denominations[i] && currentBalance >= denominations[i]) {
                remainingAmount -= denominations[i];
                currentBalance -= denominations[i];
                usedDenominations.push_back(denominations[i]);
            }
        }

        if (remainingAmount == 0) {
            std::cout << "Знято: " << amount << " гривень з наступними купюрами: ";
            for (int i = 0; i < usedDenominations.size(); i++) {
                std::cout << usedDenominations[i];
                if (i < usedDenominations.size() - 1) {
                    std::cout << ", ";
                }
            }
            std::cout << std::endl;
            return true;
        }
        else {
            std::cout << "Не вдається видати вказану суму." << std::endl;
            return false;
        }
    }

    // Метод для отримання рядкового представлення залишку в банкоматі
    std::string toString() {
        return "Залишок в банкоматі: " + std::to_string(currentBalance) + " гривень.";
    }
};