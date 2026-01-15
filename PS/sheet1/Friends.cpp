#include <iostream>
using namespace std;

int main() {
    int m;
    cin >> m;

    // adjacency matrix: know[i][j] = true if i knows j
    bool know[6][6] = {false};

    for (int i = 0; i < m; i++) {
        int a, b;
        cin >> a >> b;
        know[a][b] = true;
        know[b][a] = true;
    }

    // check all triples (i, j, k)
    for (int i = 1; i <= 5; i++) {
        for (int j = i + 1; j <= 5; j++) {
            for (int k = j + 1; k <= 5; k++) {

                bool allFriends =
                    know[i][j] && know[i][k] && know[j][k];

                bool allStrangers =
                    !know[i][j] && !know[i][k] && !know[j][k];

                if (allFriends || allStrangers) {
                    cout << "WIN" << endl;
                    return 0;
                }
            }
        }
    }

    cout << "FAIL" << endl;
    return 0;
}