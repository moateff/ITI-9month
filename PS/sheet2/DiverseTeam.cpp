#include <iostream>
#include <set>
#include <vector>

using namespace std;

int main() {
    int n, k;
    cin >> n >> k;

    vector<int> a(n);
    for (int i = 0; i < n; i++) {
        cin >> a[i];
    }

    set<int> used;          // to store used ratings
    vector<int> result;     // to store selected indices

    for (int i = 0; i < n; i++) {
        if (used.count(a[i]) == 0) {
            used.insert(a[i]);
            result.push_back(i + 1); // store index (1-based)
        }
        if ((int)result.size() == k) {
            break;
        }
    }

    if ((int)result.size() < k) {
        cout << "NO\n";
    } else {
        cout << "YES\n";
        for (int idx : result) {
            cout << idx << " ";
        }
        cout << "\n";
    }

    return 0;
}
