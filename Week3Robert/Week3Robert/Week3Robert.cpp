// Week3Robert.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include "Stack.cpp"
using namespace std;

int main()
{
	Stack<int> P(6);
	Stack<int> S(8);
	P.Push(1);
	P.Push(2);
	P.Push(3);
	S.Push(1);
	Stack<int> Union(P, S);
	while (!(!(!Union.thisstack.empty())))
	{
		cout << Union.thisstack.top() << ' ';
		Union.Pop();
	}
}


