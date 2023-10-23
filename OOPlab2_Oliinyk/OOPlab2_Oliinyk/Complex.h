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
    std::vector<int> denominations;  // ���� ��� ��������� ������� �����

public:
    Bankomat() {
        // ����������� �� �������������
    }

    void Init(std::string id, int minWithdrawal, int maxWithdrawal) {
        atmID = id;
        this->minWithdrawal = minWithdrawal;
        this->maxWithdrawal = maxWithdrawal;
        currentBalance = 0;
        denominations = { 10, 20, 50, 100, 200, 500, 1000 };
    }

    void Read() {
        std::cout << "������ ���� ��� ������������ � ��������: ";
        int amount;
        std::cin >> amount;
        loadMoney(amount);
    }

    void Display() {
        std::cout << "ID ���������: " << atmID << std::endl;
        std::cout << "̳������� ���� ��� ������: " << minWithdrawal << " �������" << std::endl;
        std::cout << "����������� ���� ��� ������: " << maxWithdrawal << " �������" << std::endl;
        std::cout << "������� � ��������: " << currentBalance << " �������" << std::endl;
    }

    // ����� ��� ������������ ����� � ��������
    void loadMoney(int amount) {
        currentBalance += amount;
    }

    // ����� ��� ������ ������ � ���������
    bool withdrawMoney(int amount) {
        if (amount < minWithdrawal || amount > maxWithdrawal) {
            std::cout << "������������ ���� ��� ������ ������." << std::endl;
            return false;
        }

        if (amount > currentBalance) {
            std::cout << "����������� ������ � ��������." << std::endl;
            return false;
        }

        // �������� �� ���������� ������� ����� ��� ������
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
            std::cout << "�����: " << amount << " ������� � ���������� ��������: ";
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
            std::cout << "�� ������� ������ ������� ����." << std::endl;
            return false;
        }
    }

    // ����� ��� ��������� ��������� ������������� ������� � ��������
    std::string toString() {
        return "������� � ��������: " + std::to_string(currentBalance) + " �������.";
    }
};