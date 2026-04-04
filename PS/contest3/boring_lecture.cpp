#include <iostream>
#include <vector>
#include <queue>
using namespace std;

bool pathOut(int i, int j, vector<vector<int>>& C) {
    int n = C.size();
    int m = C[0].size();
    
    vector<vector<bool>> visited(n, vector<bool>(m, false));
    bool found = false;

    queue<pair<int, int>> q;
    q.push({i, j});
    visited[i][j] = true;

    int dx[4] = {-1, 1, 0, 0};
    int dy[4] = {0, 0, -1, 1};

    while (!q.empty()) {
        int x = q.front().first;
        int y = q.front().second;
        q.pop();

        if (x == 0 || x == n - 1 || y == 0 || y == m - 1) {
            found = true;
            break;
        }

        for (int i = 0; i < 4; i++) {
            int nx = x + dx[i];
            int ny = y + dy[i];

            if (nx < 0 || nx >= n || ny < 0 || ny >= m) continue;
            if (visited[nx][ny]) continue;
            if (C[nx][ny] == -1) continue;

            visited[nx][ny] = true;
            q.push({nx, ny});
        }
    }

    return found;
}

int main() {
    int n, m;
    cin >> n >> m;

    vector<vector<int>> A(n, vector<int>(m));

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            cin >> A[i][j];
        }
    }

    vector<vector<int>> B(n, vector<int>(m));

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            cin >> B[i][j];
        }
    }

    vector<vector<int>> C(n, vector<int>(m, -1));
    int numOfPeopleLeft = 0;
    int time = 0;

    while (true) {
        bool change = false;

        // cout << "time = " << time << endl;

        // cout << "A = " << endl;
        // for (int i = 0; i < n; i++) {
        //     for (int j = 0; j < m; j++) {
        //         cout << A[i][j] << ' ';
        //     }
        //     cout << endl;
        // }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                // cout << i << ' ' << j << " = " << pathOut(i, j, C) << endl; 
                // cout << "A(" << i << ", " << j << ")" <<  " = " << A[i][j] << endl; 
                // cout << "B(" << i << ", " << j << ")" <<  " = " << B[i][j] << endl; 

                if (C[i][j] == -1
                    && A[i][j] == 0 
                    && B[i][j] <= numOfPeopleLeft
                    && pathOut(i, j, C)) {

                    // cout << i << ' ' << j << " = " << pathOut(i, j, C) << endl;                    
                    C[i][j] = time;
                    numOfPeopleLeft++;
                    i = 0; j = -1;
                    
                    // cout << "numOfPeopleLeft = " << numOfPeopleLeft << endl;
                    // cout << "C = " << endl;

                    // for (int i = 0; i < n; i++) {
                    //     for (int j = 0; j < m; j++) {
                    //         cout << C[i][j] << ' ';
                    //     }
                    //     cout << endl;
                    // }
                }
            }
        }

        
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (A[i][j] > 0) {
                    A[i][j]--;
                    change = true;
                }
            }
        }
        time++;
        if (!change) break;
    }

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            cout << C[i][j] << ' ';
        }
        cout << endl;
    }

    return 0;
}