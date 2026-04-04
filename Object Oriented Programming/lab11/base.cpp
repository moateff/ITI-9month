#include <iostream>

class Base {
private:   int x;             
protected: int y;         
public:    int z;        
    Base() {}
    int fun() { return x + y + z; }
};

class Derived1 : public Base {
private:   int a;               
protected: int b;            
public:    int c;             
    Derived1() : Base() {}
    int fun() { return x + y + z + a + b + c; }
};

class Derived2 : public Derived1 {
private:   int k;                
protected: int l;              
public:    int m;           
    Derived2() : Derived1() {} 
    int fun() { return x + y + z + a + b + c + k + l + m; }
};

int main() {
    Base o1;
    o1.x = 1;
    o1.y = 1;
    o1.z = 1;

    Derived1 o2;
    o2.x = 1;
    o2.y = 1;
    o2.z = 1;

    o2.a = 1;
    o2.b = 1;
    o2.c = 1;

    Derived2 o3;
    o3.x = 1;
    o3.y = 1;
    o3.z = 1;

    o3.a = 1;
    o3.b = 1;
    o3.c = 1;

    o3.k = 1;
    o3.l = 1;
    o3.m = 1;
}
