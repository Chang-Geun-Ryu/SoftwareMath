본 실습은 컴퓨터에서 해야 하는 과제입니다. 코드 작성이 끝났다면 실습 1에서 설정하였던 깃 저장소에 커밋 및 푸시를 하고 슬랙을 통해 자동으로 채점을 받으세요.

지금쯤이면 벡터와 행렬을 사용해서 할 수 있는 여러 연산들에 익숙할 겁니다. 수업 중에 봤던 예 중에 하나는 2D 공간에서 벡터를 변환하는 것이었죠. 적절한 변환 행렬만 만들면 원하는 대로 벡터를 확대/축소, 평행이동, 회전 등을 할 수 있답니다. 이것만 보고 너무 수학적이며 프로그래밍에서는 별다른 효용이 없다고 생각했나요? 노노~ 그것은 사실이 아닙니다. 실제로 컴퓨터 공학의 매우 다양한 분야에서 벡터와 행렬을 무수히 사용하고 있고, 그 몇 가지 예를 들어 드리면 다음과 같습니다.

- 영상처리
- 기계학습(머신러닝)
- 그래프 이론
- 네오(Neo)처럼 총알을 피하거나 하늘을 날아다니기... (응?)

예를 들어 머신러닝과 영상처리에서 어떤 물체나 현상에서 측정 가능한 여러 속성 및 특징들을 나타내는 벡터를 특징 벡터(feature vector)라고 합니다. 어떤 물체나 현상을 수치적으로 표현할 수 있는 실용성 및 효율 때문에 이 방법을 많이 쓰죠. 그리고 특징 벡터를 수정하거나 분석하는 방법 중 하나가 바로 행렬 연산입니다. 심지어 구글 검색엔진의 페이지랭크(PageRank) 알고리듬도 행렬 연산을 사용한답니다. 따라서 프로그래머인 우리는 모두 행렬 및 벡터로 할 수 있는 다양한 연산들을 잘 이해할 뿐만 아니라 그들을 구현할 수도 있어야 합니다.

## 1. 프로젝트를 준비한다

1. 비주얼 스튜디오에서 `Lab8.sln` 솔루션 파일을 엽니다.
2. 프로젝트에 `Matrix.cs` 파일을 추가합니다.

## 2. `Matrix.cs` 안에 있는 함수들 구현하기

### 전반적인 규칙

- `Matrix`는 정적 클래스여야 합니다.

### 2.1 `DotProduct()` 함수를 구현한다

- ```
  DotProduct()
  ```

   

  함수는 다음의 인자를 받습니다.

  - 벡터 v1: `int[] v1`
  - 벡터 v2: `int[] v2`

- `v1`과 `v2`의 내적을 반환합니다.

- `v1`와 `v2`의 길이는 언제나 동일하다고 가정하셔도 좋습니다.

```csharp
int[] v1 = new int[] { 3, 5, 1 };
int[] v2 = new int[] { -2, 4, -1 };

int dot = Matrix.DotProduct(v1, v2); // dot: 13
```

### 2.2 `Transpose()` 함수를 구현한다

- ```
  Transpose()
  ```

   

  함수는 다음의 인자를 받습니다.

  - 행렬: `int[,] matrix`

- `matrix`의 전치 행렬을 반환합니다.

```csharp
int [,] matrix = new int[4,6]
{
    { 4, 6, 1, 0, 9, 2 },
    { 1, -2, 4, 5, 5, 9 },
    { 2, -8, -2, 1, -5, 2 },
    { 10, -10, 7, 7, 9, 5 },
};

int[,] transposed = Matrix.Transpose(matrix);
// transposed:
/*
4      1      2     10
6     -2     -8    -10
1      4     -2      7
0      5      1      7
9      5     -5      9
2      9      2      5
*/
```

### 2.3 `GetIdentityMatrix()` 함수를 구현한다

- ```
  GetIdentityMatrix()
  ```

   

  함수는 다음의 인자를 받습니다.

  - 정사각 행렬의 크기: `int size`

- 크기가 `size` x `size`인 단위 행렬을 반환합니다.

```csharp
int[,] identityMatrix = Matrix.GetIdentityMatrix(3);
// identityMatrix
/*
1  0  0
0  1  0
0  0  1
*/
```

### 2.4 `GetRowOrNull()` 함수를 구현한다

- ```
  GetRowOrNull()
  ```

   

  함수는 다음의 인자를 받습니다.

  - 행렬: `int[,] matrix`
  - 행의 색인: `int row`

- `matrix`에서 `row`로 지정한 행을 반환합니다.

- `row`가 범위 밖이면 `null`을 반환합니다.

```csharp
int[,] matrix = new int[,]
{
    { 2, 4, 6, 7 },
    { 4, -1, 5, 6 },
    { -5, 6, 1, 1 }
};

int[] row = Matrix.GetRowOrNull(matrix, 1); // row: [ 4, -1, 5, 6 ]
```

### 2.5 `GetColumnOrNull()` 함수를 구현한다

- ```
  GetColumnOrNull()
  ```

   

  함수는 다음의 인자를 받습니다.

  - 행렬: `int[,] matrix`
  - 열의 색인: `int col`

- `matrix`에서 `col`로 지정한 열을 반환합니다.

- `col`이 범위 밖이면 `null`을 반환합니다.

```csharp
int[,] matrix = new int[,]
{
    { 2, 4, 6, 7 },
    { 4, -1, 5, 6 },
    { -5, 6, 1, 1 }
};

int[] col = Matrix.GetColumnOrNull(matrix, 1); // col: [ 4, -1, 6 ]
```

### 2.6 `MultiplyMatrixVectorOrNull()` 함수를 구현한다

- ```
  MultiplyMatrixVectorOrNull()
  ```

   

  함수는 다음의 인자를 받습니다.

  - 행렬: `int[,] matrix`
  - 벡터: `int[] vector`

- `matrix`와 `vector`를 곱한 결과를 반환합니다.

- 곱을 할 수 없는 경우에는 `null`을 반환합니다.

```csharp
int[,] matrix = new int[,]
{
    { 2, 4, 6, 7 },
    { 4, -1, 5, 6 },
    { -5, 6, 1, 1 }
};

int[] vector = new int[] { 1, -1, 5, 3 };

int[] product = Matrix.MultiplyMatrixVectorOrNull(matrix, vector); // product: [ 49, 48, -3 ]
```

### 2.7 `MultiplyVectorMatrixOrNull()` 함수를 구현한다

- ```
  MultiplyVectorMatrixOrNull()
  ```

   

  함수는 다음의 인자를 받습니다.

  - 벡터: `int[] vector`
  - 행렬: `int[,] matrix`

- `vector`와 `matrix`를 곱한 결과를 반환합니다.

- 곱을 할 수 없는 경우에는 `null`을 반환합니다.

```csharp
int[,] matrix = new int[,]
{
    { 2, 4, -5 },
    { 4, -1, 6 },
    { 6, 5, 1 },
    { 7, 6, 1 }

};

int[] vector = new int[] { 1, -1, 5, 3 };

int[] product = Matrix.MultiplyVectorMatrixOrNull(vector, matrix); // product: [ 49, 48, -3 ]
```

### 2.8 `MultiplyOrNull()` 함수를 구현한다

- ```
  MultiplyOrNull()
  ```

   

  함수는 다음의 인자를 받습니다.

  - 곱할 행렬 중 좌항: `int[,] multiplicandMatrix`
  - 곱할 행렬 중 우항: `int[,] multiplierMatrix`

- `multiplicandMatrix`와 `multiplierMatrix`를 곱한 결과를 반환합니다.

- 곱을 할 수 없는 경우에는 `null`을 반환합니다.

```csharp
int[,] multiplicand = new int[2, 3]
{
    { 2, 3, 1 },
    { 1, 4, 3 }
};

int[,] multiplier = new int[3, 2]
{
    { 3, 4 },
    { 1, 1 },
    { 2, 5 }
};

int[,] product = Matrix.MultiplyOrNull(multiplicand, multiplier);
// product:
/*
11     16
13     23
*/
```

## 3. 본인 컴퓨터에서 테스트하는 법

- 본인 컴퓨터에서 테스트를 하려면 `Program.cs` 파일을 아래의 예처럼 고쳐주세요.

```csharp
using System;
using System.Diagnostics;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vector1 = new int[] { 4, 7, 8, -1, 2, 5, -5, -6 };
            int[] vector2 = new int[] { 5, -6, 7, 1, 4, 6, 9, -3 };

            int dotProduct = Matrix.DotProduct(vector1, vector2);

            Debug.Assert(dotProduct == 44);

            int[,] matrix1 = new int[3, 7]
            {
                { 4, -4, 6, 4, 19, -1, 2 },
                { 6, -77, 4, 2, 5, 7, 7 },
                { 5, 8, -3, -22, 6, 6, 10 }
            };

            int[,] expectedTransposed = new int[7, 3]
            {
                { 4, 6, 5 },
                { -4, -77, 8 },
                { 6, 4, -3 },
                { 4, 2, -22 },
                { 19, 5, 6 },
                { -1, 7, 6 },
                { 2, 7, 10 }
            };

            int[,] transposed = Matrix.Transpose(matrix1);
            printMatrix(transposed);

            Debug.Assert(areMatricesEqual(expectedTransposed, transposed));

            int[,] expectedIdentityMatrix = new int[5, 5]
            {
                { 1, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1 }
            };

            int[,] identityMatrix = Matrix.GetIdentityMatrix(5);
            printMatrix(identityMatrix);

            Debug.Assert(areMatricesEqual(expectedIdentityMatrix, identityMatrix));

            int[] row = Matrix.GetRowOrNull(matrix1, 0);
            Debug.Assert(areVectorsEqual(new int[] { 4, -4, 6, 4, 19, -1, 2 }, row));

            row = Matrix.GetRowOrNull(transposed, 3);
            Debug.Assert(areVectorsEqual(new int[] { 4, 2, -22 }, row));

            int[] column = Matrix.GetColumnOrNull(matrix1, 1);
            Debug.Assert(areVectorsEqual(new int[] { -4, -77, 8 }, column));

            column = Matrix.GetColumnOrNull(transposed, 1);
            Debug.Assert(areVectorsEqual(new int[] { 6, -77, 4, 2, 5, 7, 7 }, column));

            int[] matVecProduct = Matrix.MultiplyMatrixVectorOrNull(matrix1, new int[] { 5, -5, 3, 5, 2, 1, -1 });
            Debug.Assert(areVectorsEqual(new int[] { 113, 447, -126 }, matVecProduct));

            matVecProduct = Matrix.MultiplyMatrixVectorOrNull(transposed, new int[] { 5, -5, 3, 5, 2, 1, -1 });
            Debug.Assert(matVecProduct == null);

            int[] vecMatProduct = Matrix.MultiplyVectorMatrixOrNull(new int[] { 5, -5, 3, 5, 2, 1, -1 }, transposed);
            Debug.Assert(areVectorsEqual(new int[] { 113, 447, -126 }, vecMatProduct));

            vecMatProduct = Matrix.MultiplyVectorMatrixOrNull(new int[] { 5, -5, 3, 5, 2, 1, -1 }, matrix1);
            Debug.Assert(vecMatProduct == null);

            int[,] matrix2 = new int[5, 4]
            {
                { 4, -4, 6, 4 },
                { 6, -77, 4, 2 },
                { 5, 8, -3, -22 },
                { 3, 2, -11, 5 },
                { 9, 1, -2, -9 }
            };

            Debug.Assert(Matrix.MultiplyOrNull(matrix1, matrix1) == null);
            Debug.Assert(Matrix.MultiplyOrNull(matrix1, matrix2) == null);

            int[,] matrix3 = new int[4, 7]
            {
                { 10, -2, 11, -4, 77, 3, 1 },
                { -1, -1, 5, -4, 4, 11, 1 },
                { 4, 6, -9, 100, 12, 56, 20 },
                { 7, 8, 6, 5, 1, -1, 6 }
            };

            int[,] expectedProduct = new int[5, 7]
            {
                { 96, 64, -6, 620, 368, 300, 144 },
                { 167, 105, -343, 694, 204, -607, 21 },
                { -124, -212, -10, -462, 359, -43, -179 },
                { 19, -34, 172, -1095, 112, -590, -185 },
                { 18, -103, 68, -285, 664, -65, -84 }
            };

            int[,] matProduct = Matrix.MultiplyOrNull(matrix2, matrix3);
            printMatrix(matProduct);

            Debug.Assert(areMatricesEqual(expectedProduct, matProduct));
        }

        private static bool areVectorsEqual(int[] expected, int[] actual)
        {
            if (expected.Length != actual.Length)
            {
                return false;
            }

            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool areMatricesEqual(int[,] expected, int[,] actual)
        {
            if (expected.GetLength(0) != actual.GetLength(0)
                || expected.GetLength(1) != actual.GetLength(1))
            {
                return false;
            }

            int row = expected.GetLength(0);
            int column = expected.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void printMatrix(int[,] matrix)
        {
            Console.WriteLine("---------------------------------");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, -6} ", matrix[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("---------------------------------");
        }
    }
}
```