#pragma once
#include <iostream>
#include <stdexcept>

// ������ 1: ��� ������������ ���������
int calculateDayOfWeek1(int year, int month, int day) {
    if (month < 3) {
        month += 12;
        year--;
    }

    int h = (day + 2 * month + 3 * (month + 1) / 5 + year + year / 4 - year / 100 + year / 400) % 7;

    // ��������� ��������� (0 - ��������, 1 - �������, ..., 6 - �����)
    return h;
}

// ������ 2: ǳ ������������� throw()
int calculateDayOfWeek2(int year, int month, int day) throw() {
    if (month < 3) {
        month += 12;
        year--;
    }

    int h = (day + 2 * month + 3 * (month + 1) / 5 + year + year / 4 - year / 100 + year / 400) % 7;

    // ��������� ��������� (0 - ��������, 1 - �������, ..., 6 - �����)
    return h;
}

// ������ 3: � ���������� ������������� � ��������� ����������� �����������
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

        // ��������� ��������� (0 - ��������, 1 - �������, ..., 6 - �����)
        return h;
    }
    catch (...) {
        throw MyException();
    }
}

// ������ 4: ������������ �� ������� ����������� �����������
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

        // ��������� ��������� (0 - ��������, 1 - �������, ..., 6 - �����)
        return h;
    }
    catch (...) {
        throw CustomException();
    }
}