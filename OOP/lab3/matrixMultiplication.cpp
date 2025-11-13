#include <iostream>
using namespace std;

int main() {
    int m, n, x, y;

    cout << "Enter rows and columns of matrix A: ";
    cin >> m >> n;

    cout << "Enter rows and columns of matrix B: ";
    cin >> x >> y;

    if (n != x) {
        cout << "\nMatrix multiplication not possible!" << endl;
        cout << "Columns of A (" << n << ") must equal rows of B (" << x << ")." << endl;
        return 0;
    }

    int A[m][n], B[x][y], C[m][y];

    cout << "\nEnter elements of matrix A:\n";
    for (int i = 0; i < m; ++i)
        for (int j = 0; j < n; ++j)
            cin >> A[i][j];

    cout << "\nEnter elements of matrix B:\n";
    for (int i = 0; i < x; ++i)
        for (int j = 0; j < y; ++j)
            cin >> B[i][j];

    // Initialize C to 0
    for (int i = 0; i < m; ++i)
        for (int j = 0; j < y; ++j)
            C[i][j] = 0;

    // Multiply matrices
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < y; ++j) {
            for (int k = 0; k < n; ++k) {
                C[i][j] += A[i][k] * B[k][j];
            }
        }
    }

    cout << "\nResultant Matrix (A x B):\n";
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < y; ++j)
            cout << C[i][j] << " ";
        cout << endl;
    }

    return 0;
}
