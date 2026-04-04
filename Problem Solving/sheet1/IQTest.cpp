#include <iostream>
#include <vector>
using namespace std;

int main() {
    int n;
    cin >> n;

    vector<int> arr(n);
    for (int i = 0; i < n; i++) {
        cin >> arr[i];
    }

    int evenCount = 0;
    for (int i = 0; i < 3; i++) {
        if (arr[i] % 2 == 0) evenCount++;
    }

    bool majorityEven = evenCount >= 2;

    for (int i = 0; i < n; i++) {
        if ((arr[i] % 2 == 0) != majorityEven) {
            cout << i + 1 << endl;
            break;
        }
    }

    return 0;
}
