#include <iostream>
#include "Figure.h"

int main() {
    // Створення об'єкта кола
    Circle circle(1.0, 1.0, 60.0, 2.0, 4.0);

    // Використання методів кола
    circle.show();
    circle.rotate(-30.0);
    circle.move(3.0, -1.0);
    circle.hide();

    return 0;
}
