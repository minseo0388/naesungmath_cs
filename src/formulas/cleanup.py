
import os
import sys

# keep list (C# files)
keep = [
    'BasicMath.cs',
    'Equation.cs',
    'Calculus.cs',
    'LinearAlgebra.cs',
    'Circle.cs',
    'Triangle.cs',
    'Quadrilateral.cs',
    'Polygon.cs',
    'Solid3D.cs',
    'AnalyticGeometry.cs',
    'Trigonometry.cs',
    'ArithmeticProgression.cs',
    'GeometricProgression.cs',
    'cleanup.py' 
]

current_dir = os.path.dirname(os.path.abspath(__file__))
count = 0
for file in os.listdir(current_dir):
    if file.endswith('.cs') and file not in keep:
        print(f"Deleting {file}")
        try:
             os.remove(os.path.join(current_dir, file))
             count += 1
        except Exception as e:
             print(f"Error deleting {file}: {e}")

print(f"Cleanup complete. Deleted {count} files.")
