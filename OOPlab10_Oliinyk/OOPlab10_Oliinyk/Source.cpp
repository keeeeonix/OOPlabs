#include <iostream>
#include <cmath>
#include "polymorph.h"


int main() {
    // Приклад використання класів
    VertexTriangle vt(0, 0, 3, 0, 0, 4);
    vt.printInfo();
    std::cout << "Area: " << vt.calculateArea() << std::endl;

    SideTriangle st(3, 4, 5);
    st.printInfo();
    std::cout << "Area: " << st.calculateArea() << std::endl;

    MedianTriangle mt(2, 3, 4);
    mt.printInfo();
    std::cout << "Area: " << mt.calculateArea() << std::endl;

    RightTriangle rt(0, 0, 3, 0, 0, 4);
    rt.printInfo();
    std::cout << "Inscribed Circle Radius: " << rt.calculateInscribedCircleRadius() << std::endl;
    std::cout << "Circumscribed Circle Radius: " << rt.calculateCircumscribedCircleRadius() << std::endl;

    return 0;
}
