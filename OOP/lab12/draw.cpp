#include <iostream>
#include <conio.h>
#include "graphics.h"
using namespace std;

// Abstract Base Class
class MyShape {
public:
    virtual ~MyShape() = default;
    virtual void draw() const = 0; // Pure virtual function
};

class MyPoint {
private:
    int x, y;

public:
    MyPoint() : x(0), y(0) {}
    MyPoint(int x, int y) : x(x), y(y) {}
    MyPoint(const MyPoint& p) : x(p.x), y(p.y) {}
    ~MyPoint() {}

    int getx() const { return x; }
    void setx(int x) { x = x; }

    int gety() const { return y; }
    void sety(int y) { y = y; }

    void show() const {
        cout << "(" << x << ", " << y << ")" << endl;
    }
};

class MyRectangle : public MyShape {
private:
    MyPoint upper, lower;
    int color;

public:
    MyRectangle() : upper(), lower(), color(0) {}

    MyRectangle(int color) : upper(), lower(), color(color) {}

    MyRectangle(int x1, int y1, int x2, int y2, int color)
        : upper(x1, y1), lower(x2, y2), color(color) {}

    ~MyRectangle() {}

    void draw() const override {
        setcolor(color);
        rectangle(upper.getx(), upper.gety(),
                  lower.getx(), lower.gety());
    }
};

class MyCircle : public MyShape {
private:
    MyPoint center;
    int radius, color;

public:
    MyCircle() : center(), radius(0), color(0) {}

    MyCircle(int color) : center(), radius(0), color(color) {}

    MyCircle(int x, int y, int radius, int color)
        : center(x, y), radius(radius), color(color) {}

    ~MyCircle() {}

    void draw() const override {
        setcolor(color);
        circle(center.getx(), center.gety(), radius);
    }
};

class MyLine : public MyShape {
private:
    MyPoint p1, p2;
    int color;

public:
    MyLine() : p1(), p2(), color(0) {}

    MyLine(int color) : p1(), p2(), color(color) {}

    MyLine(int x1, int y1, int x2, int y2, int color)
        : p1(x1, y1), p2(x2, y2), color(color) {}

    ~MyLine() {}

    void draw() const override {
        setcolor(color);
        line(p1.getx(), p1.gety(),
             p2.getx(), p2.gety());
    }
};

class MyTriangle : public MyShape {
private:
    MyPoint p1, p2, p3;
    int color;

public:
    MyTriangle() : p1(), p2(), p3(), color(0) {}

    MyTriangle(int color) : p1(), p2(), p3(), color(color) {}

    MyTriangle(int x1, int y1, int x2, int y2, int x3, int y3, int color)
        : p1(x1, y1), p2(x2, y2), p3(x3, y3), color(color) {}

    ~MyTriangle() {}

    void draw() const override {
        setcolor(color);
        triangle(p1.getx(), p1.gety(),
                p2.getx(), p2.gety(),
                p3.getx(), p3.gety());
    }
};

class Picture {
private:
    MyShape** shapeArr;
    int shapeCount;

public:
    Picture() : shapeArr(nullptr), shapeCount(0) {}

    Picture(MyShape** sA, int sC) {
        shapeCount = sC;
        shapeArr = (sC > 0) ? new MyShape*[sC] : nullptr;

        for (int i = 0; i < sC; i++)
            shapeArr[i] = sA[i];
    }

    ~Picture() {
        if (shapeArr) {
            for (int i = 0; i < shapeCount; i++)
                delete shapeArr[i]; // delete each derived object
            delete[] shapeArr;      // then delete the array of pointers
        }
    }

    void paint() const {
        for (int i = 0; i < shapeCount; i++)
            shapeArr[i]->draw();
    }

    void setShapes(MyShape** sA, int count) {
        // Delete existing objects and array
        if (shapeArr) {
            for (int i = 0; i < shapeCount; i++)
                delete shapeArr[i];
            delete[] shapeArr;
        }

        // Allocate new array and copy pointers
        shapeCount = count;
        shapeArr = (count > 0) ? new MyShape*[count] : nullptr;
        for (int i = 0; i < count; i++)
            shapeArr[i] = sA[i];
    }
};

int main() {
    initgraph();

    // Create dynamic polymorphic list of shapes
    MyShape* shapes[7];

    shapes[0] = new MyRectangle(162, 347, 326, 407, 1);
    shapes[1] = new MyRectangle(218, 266, 277, 348, 1);

    shapes[2] = new MyCircle(248, 224, 100, 5);
    shapes[3] = new MyCircle(248, 88, 50, 5);

    shapes[4] = new MyLine(225, 88, 200, 224, 1);
    shapes[5] = new MyLine(270, 88, 296, 224, 1);

    shapes[6] = new MyTriangle(285, 387, 310, 387, 298, 366, 5);

    // Build the picture
    Picture pic;
    pic.setShapes(shapes, 7);

    // Draw
    pic.paint();

    // Clean up dynamic memory
    for (int i = 0; i < 7; i++)
        delete shapes[i];

    return 0;
}

