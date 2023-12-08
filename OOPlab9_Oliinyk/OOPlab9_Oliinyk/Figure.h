#pragma once
#include <iostream>

// ����������� ���� "����������� ������"
class GeometricFigure {
public:
    // �����������
    GeometricFigure(double centerX, double centerY, double rotationAngle, double scaleFactor)
        : centerX_(centerX), centerY_(centerY), rotationAngle_(rotationAngle), scaleFactor_(scaleFactor) {}

    // ³������� ������, �� ������ ��������� � �������� ������
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

// �������� ���� "����"
class Circle : public GeometricFigure {
public:
    // �����������
    Circle(double centerX, double centerY, double rotationAngle, double scaleFactor, double radius)
        : GeometricFigure(centerX, centerY, rotationAngle, scaleFactor), radius_(radius) {}

    // ��������� ������
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