#include <iostream>
using namespace std;

int main() {
    int size;

    cout << "Enter the size of the matrix: ";
    cin >> size;

    for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
            if (i == j)
                cout << " * ";
            else
                cout << " - ";
        }
        cout << endl;
    }

    return 0;
}
