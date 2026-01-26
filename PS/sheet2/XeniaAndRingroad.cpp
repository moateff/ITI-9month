#include <iostream>
using namespace std;

int main() {
    int n, m;
    cin >> n >> m;

    int a[m];
    for (int i = 0; i < m; i++) {
        cin >> a[i];
    }

    int current = 1;
    long long totalTime = 0;

    for (int i = 0; i < m; i++) {
        int nextHouse = a[i];

        if (nextHouse >= current) {
            totalTime += nextHouse - current;
        } else {
            totalTime += n - (current - nextHouse);
        }
        current = nextHouse;
    }
    
    cout << totalTime << endl;
    return 0;
}