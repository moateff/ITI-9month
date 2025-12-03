#include <iostream>
#include <cmath>
#include <functional>
using namespace std;


// Abstract Base Class
class Shape {
public:
    virtual ~Shape() = default;
    virtual double calcArea() const = 0;    // pure virtual
};

class Circle : public Shape {
private:
    double radius;

public:
    Circle() : radius(0) {}
    Circle(double r) : radius(r) {}
    ~Circle() {}

    void setRadius(double r) { radius = r; }
    double getRadius() const { return radius; }

    double calcArea() const override {
        return M_PI * radius * radius;
    }
};

class Triangle : public Shape {
private:
    double base;
    double height;

public:
    Triangle() : base(0), height(0) {}
    Triangle(double b, double h) : base(b), height(h) {}
    ~Triangle() {}

    void setBase(double b) { base = b; }
    void setHeight(double h) { height = h; }

    double getBase() const { return base; }
    double getHeight() const { return height; }

    double calcArea() const override {
        return 0.5 * base * height;
    }
};

class Rectangle : public Shape {
protected:
    double width;
    double height;

public:
    Rectangle() : width(0), height(0) {}
    Rectangle(double w, double h) : width(w), height(h) {}
    ~Rectangle() {}

    void setWidth(double w) { width = w; }
    void setHeight(double h) { height = h; }

    double getWidth() const { return width; }
    double getHeight() const { return height; }

    double calcArea() const override {
        return width * height;
    }
};

class Square : public Rectangle {
public:
    Square() : Rectangle(0, 0) {}
    Square(double side) : Rectangle(side, side) {}

    void setSide(double side) {
        width = height = side;   // always equal
    }

    double getSide() const { return width; }

    // use Rectangle::calcArea()
};

double SumArea(Shape* arr[], int size) {
    double sum = 0;
    for (int i = 0; i < size; i++) 
        sum += arr[i]->calcArea();
    return sum;
}

double SumArea(reference_wrapper<Shape> arr[], int size) {
    double sum = 0;
    for (int i = 0; i < size; i++)
        sum += arr[i].get().calcArea();
    return sum;
}

int main() {
    Shape* shapesPtr[4];
    shapesPtr[0] = new Rectangle(5, 10);  // area = 50
    shapesPtr[1] = new Square(4);         // area = 16
    shapesPtr[2] = new Triangle(6, 3);    // area = 9
    shapesPtr[3] = new Circle(3);         // area ≈ 28.274

    cout << "Total area (pointer version) = "
         << SumArea(shapesPtr, 4) << endl;

    for (int i = 0; i < 4; i++)
        delete shapesPtr[i];

    Rectangle r(5, 10);
    Square s(4);
    Triangle t(6, 3);
    Circle c(3);

    reference_wrapper<Shape> shapesRef[] = { r, s, t, c };

    cout << "Total area (reference version) = "
         << SumArea(shapesRef, 4) << endl;

    getchar();
    
    return 0;
}
