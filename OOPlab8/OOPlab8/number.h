#pragma once
#include <iostream>
#include<cmath>

class Number {
public:
    Number(double value) : value_(value) {}

    double getValue() const {
        return value_;
    }

    void multiply(double factor) {
        value_ *= factor;
    }

    void divide(double divisor) {
        if (divisor != 0.0) {
            value_ /= divisor;
        }
        else {
            std::cerr << "Error: Division by zero." << std::endl;
        }
    }

private:
    double value_;
};

// Похідний клас Real
class Real : public Number {
public:
    Real(double value) : Number(value) {}

    double power(double exponent) {
        return std::pow(getValue(), exponent);
    }

    double root(double degree) {
        if (getValue() >= 0.0) {
            return std::pow(getValue(), 1.0 / degree);
        }
        else {
            std::cerr << "Error: Cannot calculate root of a negative number." << std::endl;
            return 0.0;
        }
    }
};
