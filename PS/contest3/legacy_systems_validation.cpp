#include <bits/stdc++.h>
using namespace std;

int main() {
    string y;
    cin >> y;

    set<char> distinct;
    for(char c : y)
        distinct.insert(c);

    if(distinct.size() <= 3)
        cout << "YES";
    else
        cout << "NO";

    return 0;
}
