using System;

namespace Logger;

public record class Student(FullName FullName) : Person(FullName);