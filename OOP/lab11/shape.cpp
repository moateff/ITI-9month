#include <iostream>
using namespace std;

class Shape {
protected:       
    double dim1, dim2;

    void setDim1(double d1) { dim1 = d1; }
    void setDim2(double d2) { dim2 = d2; }

public:
    Shape() : dim1(0), dim2(0) {}
    Shape(double d1, double d2) : dim1(d1), dim2(d2) {}
    ~Shape() {}

    double getDim1() const { return dim1; }
    double getDim2() const { return dim2; }

    double calcArea() { return dim1 * dim2; }
};

class Circle : public Shape {
private:
    double rad;

public:
    Circle() : Shape(), rad(0) {}
    Circle(double r) : Shape(r, r), rad(r) {}
    ~Circle() {}

    void setRad(double r) {
        rad = r;
        setDim1(r);
        setDim2(r);
    }

    double getRad() const { return rad; }

    double calcArea() { return 3.14 * rad * rad; }
};

class Triangle : public Shape {
public:
    Triangle() : Shape() {}
    Triangle(double d1, double d2) : Shape(d1, d2) {}
    ~Triangle() {}

    double calcArea() { return 0.5 * Shape::calcArea(); }
};

class Rectangle : public Shape {
public:
    Rectangle() : Shape() {}
    Rectangle(double d1, double d2) : Shape(d1, d2) {}
    ~Rectangle() {}
};

class Square : public Rectangle {
public:
    Square() : Rectangle() {}
    Square(double d) : Rectangle(d, d) {}
    ~Square() {}

    void setDim(double d) {
        setDim1(d);
        setDim2(d);
    }

    double calcArea() { return Rectangle::calcArea(); }
};

double SumArea(Rectangle* r, Square* s, Triangle* t, Circle* c,
            int rs, int ss, int ts, int cs)
{
    double sum = 0;

    for (int i = 0; i < rs; i++) sum += r[i].calcArea();
    for (int i = 0; i < ss; i++) sum += s[i].calcArea();
    for (int i = 0; i < ts; i++) sum += t[i].calcArea();
    for (int i = 0; i < cs; i++) sum += c[i].calcArea();

    return sum;
}


int main() {
    int cr = 0, cs = 0, ct = 0, cc = 0;

    Rectangle* r_arr = new Rectangle[5];
    Square* s_arr = new Square[5];
    Triangle* t_arr = new  Triangle[5];
    Circle* c_arr = new Circle[5];

    Rectangle r(5, 10);
    Square s(5);
    Triangle t(13, 7);
    Circle c(17);

    r_arr[cr++] = r;
    s_arr[cs++] = s;
    t_arr[ct++] = t;
    c_arr[cc++] = c;

    cout << "Rectangle area is: " << r.calcArea() << endl;
    cout << "Square area is: " << s.calcArea() << endl;
    cout << "Triangle area is: " << t.calcArea() << endl;
    cout << "Circle area is: " << c.calcArea() << endl;

    cout << "Sum of areas is: "
         << SumArea(r_arr, s_arr, t_arr, c_arr, cr, cs, ct, cc)
         << endl;

    return 0;
}
