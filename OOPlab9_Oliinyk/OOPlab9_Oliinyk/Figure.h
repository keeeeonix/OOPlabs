#pragma once
#include <iostream>

// Абстрактний клас "Геометрична фігура"
class GeometricFigure {
public:
    // Конструктор
    GeometricFigure(double centerX, double centerY, double rotationAngle, double scaleFactor)
        : centerX_(centerX), centerY_(centerY), rotationAngle_(rotationAngle), scaleFactor_(scaleFactor) {}

    // Віртуальні методи, що будуть реалізовані в похідних класах
    virtual void show() const = 0;
    virtual void hide() = 0;
    virtual void rotate(double angle) = 0;
    virtual void move(double deltaX, double deltaY) = 0;

protected:
    double centerX_;
    double centerY_;
    double rotationAngle_;
    double scaleFactor_;
};

// Похідний клас "Круг"
class Circle : public GeometricFigure {
public:
    // Конструктор
    Circle(double centerX, double centerY, double rotationAngle, double scaleFactor, double radius)
        : GeometricFigure(centerX, centerY, rotationAngle, scaleFactor), radius_(radius) {}

    // Реалізація методів
    void show() const override {
        std::cout << "Showing circle at (" << centerX_ << ", " << centerY_ << ") with radius " << radius_
            << std::endl;
    }

    void hide() override {
        std::cout << "Hiding circle." << std::endl;
    }

    void rotate(double angle) override {
        rotationAngle_ += angle;
        std::cout << "Rotating circle by " << angle << " degrees." << std::endl;
    }

    void move(double deltaX, double deltaY) override {
        centerX_ += deltaX;
        centerY_ += deltaY;
        std::cout << "Moving circle to (" << centerX_ << ", " << centerY_ << ")." << std::endl;
    }

private:
    double radius_;
};