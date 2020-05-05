#include "iostream"
#include "stack"
using namespace std;
#pragma once

template<typename T> class Stack
{
public:
	stack<t> thisstack;
	unsigned int length;

	Stack(unsigned int length)
	{
		this->length = length;
	}

	void Push(T a)
	{
		thisstack.push(a);
		if (thisstack.size() > this->length)
		{
			Pop();
			throw new exception("SetOverflow");
		}
	}

	void Pop()
	{
		if (!thisstack.empty())
			thisstack.pop();

	}
	
	Stack(Stack<T> s1, Stack<T> s2)
	{
		this->length = s1.thisstack.size() + s2.thisstack.size();
		stack<t> P = s1.thisstack;
		stack<t> S = s2.thisstack;
		while (!P.empty())
		{
			Push(P.top());
			P.pop();
		}
		while (!S.empty())
		{
			this->thisstack.push(S.top());
			S.pop();
		}
	}
	~Stack() {}
};

