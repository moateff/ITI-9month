#include <iostream>
using namespace std;

int main() {
    int n, k;
    cin >> n >> k;

    int arr[n];
    for (int i = 0; i < n; i++) {
        cin >> arr[i];
    }

    int result = 1000;
    int mod, dev;
    for (int i = 0; i < n; i++) {
        mod = k % arr[i];
        dev = k / arr[i];
        if (mod == 0 && dev < result)
            result = dev;
    }

    cout << result;
    return 0;
}