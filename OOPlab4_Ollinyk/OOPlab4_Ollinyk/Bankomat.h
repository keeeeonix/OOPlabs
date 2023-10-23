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
    Bankomat() : atmID("ATM_Default"), currentBalance(0), minWithdrawal(10), maxWithdrawal(10000) {
        denominations = { 10, 20, 50, 100, 200, 500, 1000 };
    }

    Bankomat(std::string id, int minWithdrawal, int maxWithdrawal)
        : atmID(id), minWithdrawal(minWithdrawal), maxWithdrawal(maxWithdrawal) {
        currentBalance = 0;
        denominations = { 10, 20, 50, 100, 200, 500, 1000 };
    }

    Bankomat(const Bankomat& other) {
        atmID = other.atmID;
        currentBalance = other.currentBalance;
        minWithdrawal = other.minWithdrawal;
        maxWithdrawal = other.maxWithdrawal;
        denominations = other.denominations;
    }

    Bankomat& operator=(const Bankomat& other) {
        if (this == &other) {
            return *this;
        }
        atmID = other.atmID;
        currentBalance = other.currentBalance;
        minWithdrawal = other.minWithdrawal;
        maxWithdrawal = other.maxWithdrawal;
        denominations = other.denominations;
        return *this;
    }

    Bankomat operator+(const Bankomat& other) const {
        Bankomat result;
        result.currentBalance = currentBalance + other.currentBalance;
        // Інші поля можна об'єднати, якщо потрібно
        return result;
    }

    bool operator==(const Bankomat& other) const {
        return (atmID == other.atmID) && (currentBalance == other.currentBalance) &&
            (minWithdrawal == other.minWithdrawal) && (maxWithdrawal == other.maxWithdrawal) &&
            (denominations == other.denominations);
    }

    friend std::ostream& operator<<(std::ostream& os, const Bankomat& atm) {
        os << "ID банкомату: " << atm.atmID << std::endl;
        os << "Мінімальна сума для зняття: " << atm.minWithdrawal << " гривень" << std::endl;
        os << "Максимальна сума для зняття: " << atm.maxWithdrawal << " гривень" << std::endl;
        os << "Залишок в банкоматі: " << atm.currentBalance << " гривень" << std::endl;
        return os;
    }

    void Display() {
        std::cout << "ID банкомату: " << atmID << std::endl;
        std::cout << "Мінімальна сума для зняття: " << minWithdrawal << " гривень" << std::endl;
        std::cout << "Максимальна сума для зняття: " << maxWithdrawal << " гривень" << std::endl;
        std::cout << "Залишок в банкоматі: " << currentBalance << " гривень" << std::endl;
    }

    // Перевантажений метод loadMoney бо інакше не працює ¯\_(ツ)_/¯
    void loadMoney(int amount) {
        currentBalance += amount;
    }

    void loadMoney(std::vector<int> money) {
        for (int i = 0; i < money.size(); i++) {
            currentBalance += money[i];
        }
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