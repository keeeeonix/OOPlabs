#pragma once
#include<iostream>
#include<cmath>

// Абстрактний клас трикутників
class Triangle {
public:
    virtual double calculateArea() const = 0;
    virtual void printInfo() const = 0;
};  

// Реалізація трикутника за трьома вершинами
class VertexTriangle : public Triangle {
public:
    VertexTriangle(double x1, double y1, double x2, double y2, double x3, double y3)
        : x1_(x1), y1_(y1), x2_(x2), y2_(y2), x3_(x3), y3_(y3) {}

    double calculateArea() const override {
        return 0.5 * std::abs(x1_ * (y2_ - y3_) + x2_ * (y3_ - y1_) + x3_ * (y1_ - y2_));
    }

    void printInfo() const override {
        std::cout << "Triangle with vertices (" << x1_ << ", " << y1_ << "), (" << x2_ << ", " << y2_
            << "), (" << x3_ << ", " << y3_ << ")" << std::endl;
    }
    double x1_, y1_, x2_, y2_, x3_, y3_;
};

// Реалізація трикутника за трьома сторонами
class SideTriangle : public Triangle {
public:
    SideTriangle(double a, double b, double c) : a_(a), b_(b), c_(c) {}

    double calculateArea() const override {
        double s = (a_ + b_ + c_) / 2.0;
        return std::sqrt(s * (s - a_) * (s - b_) * (s - c_));
    }

    void printInfo() const override {
        std::cout << "Triangle with sides " << a_ << ", " << b_ << ", " << c_ << std::endl;
    }

private:
    double a_, b_, c_;
};

// Клас трикутника з конструктором за медіанами
class MedianTriangle : public Triangle {
public:
    MedianTriangle(double ma, double mb, double mc) : ma_(ma), mb_(mb), mc_(mc) {}

    double calculateArea() const override {
        // Використовуємо формулу Герона для трикутника, що має сторони, рівні медіанам
        double s = (ma_ + mb_ + mc_) / 2.0;
        return std::sqrt(s * (s - ma_) * (s - mb_) * (s - mc_));
    }

    void printInfo() const override {
        std::cout << "Triangle with medians " << ma_ << ", " << mb_ << ", " << mc_ << std::endl;
    }

private:
    double ma_, mb_, mc_;
};

// Функція для обчислення паралельної середньої лінії за стороною трикутника
double calculateParallelMedian(double side) {
    return 0.5 * side;
}

// Клас прямокутного трикутника, який успадковує від VertexTriangle
class RightTriangle : public VertexTriangle {
public:
    RightTriangle(double x1, double y1, double x2, double y2, double x3, double y3)
        : VertexTriangle(x1, y1, x2, y2, x3, y3) {}

    // Функція для обчислення радіусу вписаного кола
    double calculateInscribedCircleRadius() const {
        double a = std::sqrt((x2_ - x1_) * (x2_ - x1_) + (y2_ - y1_) * (y2_ - y1_));
        double b = std::sqrt((x3_ - x2_) * (x3_ - x2_) + (y3_ - y2_) * (y3_ - y2_));
        double c = std::sqrt((x1_ - x3_) * (x1_ - x3_) + (y1_ - y3_) * (y1_ - y3_));
        double s = calculateArea();

        return s / (0.5 * (a + b + c));
    }

    // Функція для обчислення радіусу описаного кола
    double calculateCircumscribedCircleRadius() const {
        double a = std::sqrt((x2_ - x1_) * (x2_ - x1_) + (y2_ - y1_) * (y2_ - y1_));
        double b = std::sqrt((x3_ - x2_) * (x3_ - x2_) + (y3_ - y2_) * (y3_ - y2_));
        double c = std::sqrt((x1_ - x3_) * (x1_ - x3_) + (y1_ - y3_) * (y1_ - y3_));

        return (a * b * c) / (4.0 * calculateArea());
    }
};
