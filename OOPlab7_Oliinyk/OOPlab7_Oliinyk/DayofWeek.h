#pragma once
#include <iostream>
#include <stdexcept>

// Варіант 1: Без специфікації виключень
int calculateDayOfWeek1(int year, int month, int day) {
    if (month < 3) {
        month += 12;
        year--;
    }

    int h = (day + 2 * month + 3 * (month + 1) / 5 + year + year / 4 - year / 100 + year / 400) % 7;

    // Фактичний результат (0 - понеділок, 1 - вівторок, ..., 6 - неділя)
    return h;
}

// Варіант 2: Зі специфікацією throw()
int calculateDayOfWeek2(int year, int month, int day) throw() {
    if (month < 3) {
        month += 12;
        year--;
    }

    int h = (day + 2 * month + 3 * (month + 1) / 5 + year + year / 4 - year / 100 + year / 400) % 7;

    // Фактичний результат (0 - понеділок, 1 - вівторок, ..., 6 - неділя)
    return h;
}

// Варіант 3: З конкретною специфікацією з відповідним стандартним виключенням
class MyException : public std::exception {
public:
    const char* what() const throw() {
        return "Custom exception occurred.";
    }
};

int calculateDayOfWeek3(int year, int month, int day) throw(MyException) {
    try {
        if (month < 3) {
            month += 12;
            year--;
        }

        int h = (day + 2 * month + 3 * (month + 1) / 5 + year + year / 4 - year / 100 + year / 400) % 7;

        // Фактичний результат (0 - понеділок, 1 - вівторок, ..., 6 - неділя)
        return h;
    }
    catch (...) {
        throw MyException();
    }
}

// Варіант 4: Специфікація із власним реалізованим виключенням
class CustomException {
public:
    const char* getErrorMessage() const {
        return "Custom exception occurred.";
    }
};

int calculateDayOfWeek4(int year, int month, int day) throw(CustomException) {
    try {
        if (month < 3) {
            month += 12;
            year--;
        }

        int h = (day + 2 * month + 3 * (month + 1) / 5 + year + year / 4 - year / 100 + year / 400) % 7;

        // Фактичний результат (0 - понеділок, 1 - вівторок, ..., 6 - неділя)
        return h;
    }
    catch (...) {
        throw CustomException();
    }
}