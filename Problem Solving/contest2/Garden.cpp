#include <iostream>
#include <vector>
using namespace std;

int main() {
    int n, k;
    cin >> n >> k;

    vector<int> a(n);
    for (int i = 0; i < n; i++) cin >> a[i];

    int best = 1;
    for (int ai : a) {
        if (k % ai == 0) {
            if (ai > best) best = ai;
        }
    }

    cout << k / best << endl;
    return 0;
}
