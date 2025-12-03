#include <iostream>
#include <conio.h>
#include "graphics.h"
using namespace std;

class MyPoint {
private:
    int x, y;

public:
    MyPoint() : x(0), y(0) {}
    MyPoint(int x, int y) : x(x), y(y) {}
    MyPoint(const MyPoint& p) : x(p.x), y(p.y) {}

    int getx() const { return x; }
    void setx(int x) { x = x; }

    int gety() const { return y; }
    void sety(int y) { y = y; }

    void show() const {
        cout << "(" << x << ", " << y << ")" << endl;
    }
};

class MyRectangle {
private:
    MyPoint upper, lower;
    int color;

public:
    MyRectangle(int color) : upper(), lower(), color(color) {}

    MyRectangle(int x1, int y1, int x2, int y2, int color)
        : upper(x1, y1), lower(x2, y2), color(color) {}

    void draw() {
        setcolor(color);
        rectangle(upper.getx(), upper.gety(),
                  lower.getx(), lower.gety());
    }
};

class MyCircle {
private:
    MyPoint center;
    int radius, color;

public:
    MyCircle(int color) : center(), radius(0), color(color) {}

    MyCircle(int x, int y, int radius, int color)
        : center(x, y), radius(radius), color(color) {}

    void draw() {
        setcolor(color);
        circle(center.getx(), center.gety(), radius);
    }
};

class MyLine {
private:
    MyPoint p1, p2;
    int color;

public:
    MyLine(int color) : p1(), p2(), color(color) {}

    MyLine(int x1, int y1, int x2, int y2, int color)
        : p1(x1, y1), p2(x2, y2), color(color) {}

    MyLine(const MyLine& line)
        : p1(line.p1), p2(line.p2), color(line.color) {}

    void draw() {
        setcolor(color);
        line(p1.getx(), p1.gety(),
             p2.getx(), p2.gety());
    }
};

class MyTriangle {
private:
    MyPoint p1, p2, p3;
    int color;

public:
    MyTriangle(int color) : p1(), p2(), p3(), color(color) {}

    MyTriangle(int x1, int y1, int x2, int y2, int x3, int y3, int color)
        : p1(x1, y1), p2(x2, y2), p3(x3, y3), color(color) {}

    void draw() {
        setcolor(color);
        triangle(p1.getx(), p1.gety(),
                p2.getx(), p2.gety(),
                p3.getx(), p3.gety());
    }
};

int main() {
    initgraph();
    
    // rectangles
    MyRectangle r1(162, 347, 326, 407, 1);
    MyRectangle r2(218, 266, 277, 348, 1);

    // Circles 
    MyCircle c1(248, 224, 100, 5);
    MyCircle c2(248, 88, 50, 5);

    // lines
    MyLine l3(225, 88, 200, 224, 1);
    MyLine l4(270, 88, 296, 224, 1);

    // triangle
    MyTriangle t(285, 387, 310, 387, 298, 366, 5);

    // draw everything
    r1.draw();
    r2.draw();
    l3.draw();
    l4.draw();
    c1.draw();
    c2.draw();
    t.draw();

    _getch();
    return 0;
}
