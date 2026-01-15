#include <iostream>
using namespace std;

int main() {
    int n;
    cin >> n;

    int arr[n][4];
    for(int i = 0; i < n; i++) {
        for (int j = 0; j < 4; j++) {
            cin >> arr[i][j];
        }
    }

    int bestIndex = -1;
    int bestCost = 1e9;

    for(int i = 0; i < n; i++) {
        bool outdated = false;
        
        for (int j = 0; j < n; j++) {
            if (i == j) {
                continue;
            }

            if (arr[j][0] > arr[i][0] && 
                arr[j][1] > arr[i][1] &&
                arr[j][2] > arr[i][2]) {
                outdated = true;
                break;
            }
        }

        if (!outdated && arr[i][3] < bestCost) {
            bestCost = arr[i][3];
            bestIndex = i;
        }
    }

    cout << bestIndex + 1 << endl;
    return 0;
}