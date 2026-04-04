#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int main() {
    int n;
    cin >> n;

    vector<string> s(n);
    for (int i = 0; i < n; i++)
        cin >> s[i];
    
    vector<pair<string, string>> a(n);
    for (int i = 0; i < n; i++) {
        string index = s[i].substr(0, s[i].find('-'));
        string name = s[i].substr(s[i].find('-') + 1, s[i].size());
        a[i].first = name;
        a[i].second = index;
    }

    sort(a.begin(), a.end());

    for (int i = 0; i < n; i++)
        cout << a[i].second << '-' << a[i].first << endl;

    return 0;
}
