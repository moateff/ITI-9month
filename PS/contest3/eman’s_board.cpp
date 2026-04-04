#include <bits/stdc++.h>
using namespace std;

int main() {
    int N, M;
    cin >> N >> M;

    vector<string> board(N);
    for (int i = 0; i < N; i++) {
        cin >> board[i];
    }

    vector<int> fullRow(N, 1), fullCol(M, 1);

    // check rows
    for (int i = 0; i < N; i++) {
        for (int j = 0; j < M; j++) {
            if (board[i][j] == '.') {
                fullRow[i] = 0;
                break;
            }
        }
    }

    // check columns
    for (int j = 0; j < M; j++) {
        for (int i = 0; i < N; i++) {
            if (board[i][j] == '.') {
                fullCol[j] = 0;
                break;
            }
        }
    }

    long long R = 0, C = 0;
    for (int i = 0; i < N; i++) R += fullRow[i];
    for (int j = 0; j < M; j++) C += fullCol[j];

    long long maximum = R * C;
    long long minimum = max(R, C);

    cout << maximum << " " << minimum << endl;

    return 0;
}
