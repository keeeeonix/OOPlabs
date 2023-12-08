#include <iostream>
#include <cmath>
#include "number.h"


int main() {
    // ��������� ��'���� �������� �����
    Number baseNumber(5.0);

    // ������������ ������ �������� �����
    std::cout << "Base Number: " << baseNumber.getValue() << std::endl;
    baseNumber.multiply(2.0);
    std::cout << "Multiplied by 2: " << baseNumber.getValue() << std::endl;
    baseNumber.divide(3.0);
    std::cout << "Divided by 3: " << baseNumber.getValue() << std::endl;

    // ��������� ��'���� ��������� �����
    Real realNumber(25.0);

    // ������������ ������ ��������� �����
    std::cout << "Real Number: " << realNumber.getValue() << std::endl;
    double resultPower = realNumber.power(2.0);
    std::cout << "Squared: " << resultPower << std::endl;
    double resultRoot = realNumber.root(2.0);
    std::cout << "Square root: " << resultRoot << std::endl;

    return 0;
}
