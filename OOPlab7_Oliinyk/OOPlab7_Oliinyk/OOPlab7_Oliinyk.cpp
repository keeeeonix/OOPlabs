// OOPlab7_Oliinyk.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <stdexcept>
#include <string>
#include <Windows.h>
#include "DayofWeek.h"

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    try{
        // Варіант 1
        int result = calculateDayOfWeek1(2023, 11, 27);
        std::string strresult;
        switch (result) {
        case 0:
            strresult = "Понеділок";
            break;
        case 1:
            strresult = "Вівторок";
            break;
        case 2:
            strresult = "Середа";
            break;
        case 3:
            strresult = "Четвер";
            break;
        case 4:
            strresult = "П'ятниця";
            break;
        case 5:
            strresult = "Субота";
            break;
        case 6:
            strresult = "Неділя";
            break;
        default:
            throw std::out_of_range("Invalid DayofWeek value");
        }
        std::cout << "Result1: " << strresult << std::endl;
    }
        catch (...) {
        std::cerr << "An unexpected error occurred." << std::endl;
    }
        try {
            // Варіант 2
            int result = calculateDayOfWeek2(2023, 11, 28);
            std::string strresult;
            switch (result) {
            case 0:
                strresult = "Понеділок";
                break;
            case 1:
                strresult = "Вівторок";
                break;
            case 2:
                strresult = "Середа";
                break;
            case 3:
                strresult = "Четвер";
                break;
            case 4:
                strresult = "П'ятниця";
                break;
            case 5:
                strresult = "Субота";
                break;
            case 6:
                strresult = "Неділя";
                break;
            default:
                throw std::out_of_range("Invalid DayofWeek value");
            }
            std::cout << "Result2: " << strresult << std::endl;
        }
        catch (...) {
            std::cerr << "An unexpected error occurred." << std::endl;
        }
        try {
            // Варіант 3
            int result = calculateDayOfWeek3(2023, 11, 29);
            std::string strresult;
            switch (result) {
            case 0:
                strresult = "Понеділок";
                break;
            case 1:
                strresult = "Вівторок";
                break;
            case 2:
                strresult = "Середа";
                break;
            case 3:
                strresult = "Четвер";
                break;
            case 4:
                strresult = "П'ятниця";
                break;
            case 5:
                strresult = "Субота";
                break;
            case 6:
                strresult = "Неділя";
                break;
            default:
                throw std::out_of_range("Invalid DayofWeek value");
            }
            std::cout << "Result3: " << strresult << std::endl;
        }
        catch (...) {
            std::cerr << "An unexpected error occurred." << std::endl;
        }
        try {
            // Варіант 4
            int result = calculateDayOfWeek4(2023, 11, 30);
            std::string strresult;
            switch (result) {
            case 0:
                strresult = "Понеділок";
                break;
            case 1:
                strresult = "Вівторок";
                break;
            case 2:
                strresult = "Середа";
                break;
            case 3:
                strresult = "Четвер";
                break;
            case 4:
                strresult = "П'ятниця";
                break;
            case 5:
                strresult = "Субота";
                break;
            case 6:
                strresult = "Неділя";
                break;
            default:
                throw std::out_of_range("Invalid DayofWeek value");
            }
            std::cout << "Result4: " << strresult << std::endl;
        }
        catch (...) {
            std::cerr << "An unexpected error occurred." << std::endl;
        }
    return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
