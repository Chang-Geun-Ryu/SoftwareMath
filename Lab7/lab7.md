본 실습은 컴퓨터에서 해야 하는 과제입니다. 코드 작성이 끝났다면 실습 1에서 설정하였던 깃 저장소에 커밋 및 푸시를 하고 슬랙을 통해 자동으로 채점을 받으세요.

비트 플래그를 사용하면 여러 개의 불 값들을 표현할 수 있다고 수업 중에 배웠습니다. 각 비트는 0(거짓) 또는 1(참)을 나타내죠. 그러나 '그 대신 그냥 여러 개의 불 변수를 쓰면 안 되나?'라는 의문을 가지는 분도 있을 법하네요. 아무래도 불 변수를 그대로 사용하는 게 훨씬 읽거나 이해하기 쉬우니까요. 그러나 불 변수에 필요한 메모리를 생각해 봅시다. 불 변수는 하나 당 4바이트의 메모리 공간을 사용합니다. 따라서 10개의 불 값을 저장하려면 40바이트가 필요하죠. 그 대신 비트 플래그를 쓰면요? 10**비트**만 필요하네요!

여러분은 안경테를 파는 온라인 쇼핑몰을 운영하고 있습니다. 웹사이트에 있는 검색 페이지는 현재 판매 중인 모든 안경테를 보여줍니다. 하지만 고객들이 그 모든 걸 일일이 스크롤하며 읽을 리는 없겠죠? 그 대신 어떤 조건(특징, feature) 을 만족하는 안경테만 보고 싶어 할 겁니다. 예를 들면 원형인 검은색 안경테와 같이 말이지요. 아니면 안경테를 색상, 모양 순으로 정렬하고 싶을 수도 있겠네요. 이런 일을 하려면 각 안경테마다 어떤 특징이 있는지 기록해놔야 합니다. 이럴 때 비트 플래그를 이용하면 매우 괜찮을 것 같네요.

이 실습에서는 `Frame` 클래스를 구현하고 `EFeatures` 비트 플래그를 사용하는 `FilterEngine` 클래스를 구현하여 다양한 필터링 연산을 수행해 볼 것입니다.

## 1. 프로젝트를 준비한다

1. 비주얼 스튜디오에서 `Lab7.sln` 솔루션 파일을 엽니다.
2. 프로젝트에 `EFeatures.cs` 파일을 추가합니다.
3. 프로젝트에 `Frame.cs` 파일을 추가합니다.
4. 프로젝트에 `FilterEngine.cs` 파일을 추가합니다.

## 2. 구현하기

### 전반적인 규칙

- `Enum.HasFlag()` 메서드의 사용을 금합니다. 사용하면 0점이 뜨니 시도조차 하지 마세요. :)
- 아래에서 제시하는 클래스 이름, 열거형 이름, 열거형 값 이름, 프로퍼티 이름, 메서드 시그내처를 따르지 않으면 빌드봇이 빌드 오류를 일으킬 것입니다. 따라서 본인 컴퓨터에서 먼저 테스트를 하는 걸 잊지 마세요!

### 2.1 `EFeatures` 열거형을 구현한다

- 안경테는 다음과 같은 특징(feature)들을 가집니다.
  - 기본(Default)
  - 남성(Men)
  - 여성(Women)
  - 사각형(Rectangle)
  - 원형(Round)
  - 비행사(Aviator)
  - 빨강(Red)
  - 파랑(Blue)
  - 검정(Black)
- `Default` 값은 엄밀히 말하면 특징이 아니라는 사실에 유념해 주세요. 이것은 `Frame` 개체를 생성할 때 `Features` 프로퍼티가 0으로 초기화되도록 만드는 기본 값일 뿐입니다. `EFeatures`를 매개변수로 취하는 어떤 메서드가 호출될 때 `Default` 값은 절대 들어오지 않는다고 가정하셔도 좋습니다.
- 열거형을 비트 플래그로 사용하려면 열거형 선언 위에 `FlagsAttribute`를 사용하고 각 열거형 값마다 적절한 정수 값을 대입해줘야 합니다. 아래의 예에 이미 `FlagsAttribute`를 적용해놨으니 여기에 모든 특징들을 추가해서 완성시킨 뒤 사용하세요.

```csharp
[Flags]
public enum EFeatures
{
    Default = 0,
    Men = 1,
    Women = 2,
    Rectangle = 4
    // 나머지는 직접 채워 넣을 것
}
```

### 2.2 `Frame` 클래스의 구현

#### 2.2.1 생성자를 구현한다

- 생성자는 다음의 인자들을 받습니다.
  - 안경테마다 고유한 ID: `uint id`
  - 안경테의 이름: `string name`

```csharp
Frame frame = new Frame(1, "Ray-ban");
```

#### 2.2.2 프로퍼티들을 구현한다

- ```
  Frame
  ```

   

  클래스에는 다음과 같은 public 프로퍼티들이 있어야 합니다.

  - `EFeatures Features`: 특징들을 나타내는 비트 플래그
  - `uint ID`: `Frame` 개체의 고유 ID
  - `string Name`: `Frame` 개체의 이름

- 모든 프로퍼티들을 클래스 외부에서 변경할 수 없어야 합니다.

- `Features` 프로퍼티의 초기값은 `EFeatures.Default`로 설정해 주세요.

#### 2.2.3 `ToggleFeatures()` 메서드를 구현한다

- ```
  ToggleFeatures()
  ```

   

  메서드는 다음의 인자를 받습니다.

  - 토글할 특징들을 나타내는 비트 플래그: `EFeatures features`

- `features`에 지정된 특징들을 토글합니다. 토글(toggle)은 불 값을 반전시키는 연산입니다.

- 이 메서드는 아무것도 반환하지 않습니다.

```csharp
Frame frame = new Frame(1, "Ray-ban");
frame.ToggleFeatures(EFeatures.Men); // frame.Features: Men
frame.ToggleFeatures(EFeatures.Men | EFeatures.Women | EFeatures.Black); // frame.Features: Women | Black
frame.ToggleFeatures(EFeatures.Women); // frame.Features: Black
```

#### 2.2.4 `TurnOnFeatures()` 메서드를 구현한다

- ```
  TurnOnFeatures()
  ```

   

  메서드는 다음의 인자를 받습니다.

  - 참으로 바꿀 특징들을 나타내는 비트 플래그: `EFeatures features`

- `features`에 지정된 특징들을 켭니다.

- 이 메서드는 아무것도 반환하지 않습니다.

```csharp
Frame frame = new Frame(1, "Ray-ban");
frame.TurnOnFeatures(EFeatures.Men); // frame.Features: Men
frame.TurnOnFeatures(EFeatures.Men | EFeatures.Women | EFeatures.Black); // frame.Features: Men | Women | Black
```

#### 2.2.5 `TurnOffFeatures()` 메서드를 구현한다

- ```
  TurnOffFeatures()
  ```

   

  메서드는 다음의 인자를 받습니다.

  - 거짓으로 바꿀 특징들을 나타내는 비트 플래그: `EFeatures features`

- `features`에 지정된 특징들을 끕니다.

- 이 메서드는 아무것도 반환하지 않습니다.

```csharp
Frame frame = new Frame(1, "Ray-ban");
frame.TurnOffFeatures(EFeatures.Men); // frame.Features: Default
frame.TurnOnFeatures(EFeatures.Men | EFeatures.Women | EFeatures.Black); // frame.Features: Men | Women | Black
frame.TurnOffFeatures(EFeatures.Men | EFeatures.Black); // frame.Features: Women
```

### 2.3 `FilterEngine` 클래스의 구현

- `FilterEngine` 클래스는 정적(static) 클래스입니다.

#### 2.3.1 `FilterFrames()` 메서드를 구현한다

- ```
  FilterFrames()
  ```

   

  메서드는 다음의 인자를 받습니다.

  - 필터링할 안경테 목록: `List frames`
  - 특징을 담고 있는 비트 플래그: `EFeatures features`

- `features` 비트 플래그에 지정된 특징들을 가지는 안경테들을 세로운 리스트로 반환합니다.

```csharp
List<Frame> frames = new List<Frame>
{
    new Frame(1, "Glasses 1"),
    new Frame(2, "Glasses 2"),
    new Frame(3, "Glasses 3"),
    new Frame(4, "Glasses 4")
};

frames[0].TurnOnFeatures(EFeatures.Men | EFeatures.Women);
frames[1].TurnOnFeatures(EFeatures.Women | EFeatures.Aviator | EFeatures.Black);
frames[2].TurnOnFeatures(EFeatures.Rectangle | EFeatures.Black);
frames[3].TurnOnFeatures(EFeatures.Round | EFeatures.Red);

List<Frame> filteredFrames = FilterEngine.FilterFrames(frames, EFeatures.Black | EFeatures.Men); // filteredFrames: [ Glasses 1, Glasses 2, Glasses 3 ]
```

#### 2.3.2 `FilterOutFrames()` 메서드를 구현한다

- ```
  FilterOutFrames()
  ```

   

  메서드는 다음의 인자를 받습니다.

  - 필터링할 안경테 목록: `List frames`
  - 특징을 담고 있는 비트 플래그: `EFeatures features`

- `features` 비트 플래그에 지정된 특징들을 전혀 가지지 않는 안경테들을 세로운 리스트로 반환합니다.

```csharp
List<Frame> frames = new List<Frame>
{
    new Frame(1, "Glasses 1"),
    new Frame(2, "Glasses 2"),
    new Frame(3, "Glasses 3"),
    new Frame(4, "Glasses 4")
};

frames[0].TurnOnFeatures(EFeatures.Men | EFeatures.Women);
frames[1].TurnOnFeatures(EFeatures.Women | EFeatures.Aviator | EFeatures.Black);
frames[2].TurnOnFeatures(EFeatures.Rectangle | EFeatures.Black);
frames[3].TurnOnFeatures(EFeatures.Round | EFeatures.Red);

List<Frame> filteredOutFrames = FilterEngine.FilterOutFrames(frames, EFeatures.Red | EFeatures.Women); // filteredOutFrames: [ Glasses 3 ]
```

#### 2.3.3 `Intersect()` 메서드를 구현한다

- ```
  Intersect()
  ```

   

  메서드는 다음의 인자를 받습니다.

  - 안경테 목록: `List frames1`
  - 안경테 목록: `List frames2`

- `frames1`과 `frames2`의 교집합을 반환합니다.

```csharp
List<Frame> frames1 = new List<Frame>
{
    new Frame(1, "Glasses 1"),
    new Frame(2, "Glasses 2"),
    new Frame(3, "Glasses 3"),
    new Frame(4, "Glasses 4")
};

List<Frame> frames2 = new List<Frame>
{
    new Frame(1, "Glasses 1"),
    new Frame(5, "Glasses 5"),
    new Frame(6, "Glasses 6"),
    new Frame(3, "Glasses 3")
};

List<Frame> intersect = FilterEngine.Intersect(frames1, frames2); // intersect: [ Glasses 1, Glasses 3 ]
```

#### 2.3.4 `GetSortKeys()` 메서드를 구현한다

- ```
  GetSortKeys()
  ```

   

  메서드는 다음의 인자를 받습니다.

  - 안경테 목록: `List frames`
  - 우선순위에 따라 지정된 특징 목록: `List features`. 이때 각 요소는 한 개의 특징만을 나타내며, 따라서 이 경우에는 비트 플래그가 아닙니다.

- 각 안경테로부터 정렬 키(정렬의 기준으로 사용할 정수)를 생성하여 `List`로 반환합니다. 나중에 이 정렬 키를 사용하여 `frames` 리스트를 정렬할 때, `features`에 지정된 특징의 순서대로 정렬이 돼야 합니다.

- 정렬 키 리스트를 사용하는 예는 아래를 참고해주세요.

```csharp
List<Frame> frames = new List<Frame>
{
    new Frame(1, "Glasses 1"),
    new Frame(2, "Glasses 2"),
    new Frame(3, "Glasses 3"),
    new Frame(4, "Glasses 4"),
    new Frame(5, "Glasses 5"),
    new Frame(6, "Glasses 6"),
    new Frame(7, "Glasses 7")
};

frames[0].TurnOnFeatures(EFeatures.Men | EFeatures.Women | EFeatures.Rectangle | EFeatures.Blue);
frames[1].TurnOnFeatures(EFeatures.Women | EFeatures.Black);
frames[2].TurnOnFeatures(EFeatures.Aviator | EFeatures.Red | EFeatures.Black);
frames[3].TurnOnFeatures(EFeatures.Round);
frames[4].TurnOnFeatures(EFeatures.Round | EFeatures.Red);
frames[5].TurnOnFeatures(EFeatures.Men | EFeatures.Blue | EFeatures.Black);
frames[6].TurnOnFeatures(EFeatures.Black);

List<int> sortKeys = FilterEngine.GetSortKeys(frames, new List<EFeatures> { EFeatures.Rectangle, EFeatures.Black, EFeatures.Women });

List<Tuple<int, Frame>> tuples = new List<Tuple<int, Frame>>();

for (int i = 0; i < sortKeys.Count; i++)
{
    tuples.Add(new Tuple<int, Frame>(sortKeys[i], frames[i]));
}

tuples.Sort((t1, t2) =>
{
    return t2.Item1 - t1.Item1;
});

List<Frame> sortedFrames = tuples.Select(t => t.Item2).ToList(); // sortedFrames: [ Glasses 1, Glasses 2, (Glasses 3 또는 Glasses 6 또는 Glasses 7), (Glasses 3 또는 Glasses 6 또는 Glasses 7), (Glasses 3 또는 Glasses 6 또는 Glasses 7), (Glasses 4 또는 Glasses 5), (Glasses 4 또는 Glasses 5) ]
```

## 3. 본인 컴퓨터에서 테스트하는 법

- 본인 컴퓨터에서 테스트를 하려면 `Program.cs` 파일을 아래의 예처럼 고쳐주세요.

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Frame frame1 = new Frame(1, "Ray-Ban");

            frame1.ToggleFeatures(EFeatures.Aviator | EFeatures.Red);
            Debug.Assert(frame1.Features == (EFeatures.Aviator | EFeatures.Red));

            frame1.ToggleFeatures(EFeatures.Aviator);
            Debug.Assert(frame1.Features == EFeatures.Red);

            frame1.TurnOffFeatures(EFeatures.Aviator | EFeatures.Red);
            Debug.Assert(frame1.Features == 0);

            frame1.TurnOnFeatures(EFeatures.Blue | EFeatures.Black);
            Debug.Assert(frame1.Features == (EFeatures.Blue | EFeatures.Black));

            frame1.TurnOnFeatures(EFeatures.Men | EFeatures.Women);
            Debug.Assert(frame1.Features == (EFeatures.Blue | EFeatures.Black | EFeatures.Men | EFeatures.Women));

            List<Frame> frames = new List<Frame>
            {
                new Frame(2, "Joseph-Marc"),
                new Frame(3, "Derek Cardigan"),
                new Frame(4, "Randy Jackson"),
                new Frame(5, "Evergreen"),
                new Frame(6, "Emporio Armani"),
                new Frame(7, "Carrera"),
                new Frame(8, "Crocs")
            };

            frames[0].TurnOnFeatures(EFeatures.Men | EFeatures.Women | EFeatures.Rectangle | EFeatures.Blue);
            frames[1].TurnOnFeatures(EFeatures.Women | EFeatures.Black);
            frames[2].TurnOnFeatures(EFeatures.Aviator | EFeatures.Red | EFeatures.Black);
            frames[3].TurnOnFeatures(EFeatures.Round);
            frames[4].TurnOnFeatures(EFeatures.Round | EFeatures.Red);
            frames[5].TurnOnFeatures(EFeatures.Men | EFeatures.Blue | EFeatures.Black);
            frames[6].TurnOnFeatures(EFeatures.Black);

            List<Frame> filteredFrames = FilterEngine.FilterFrames(frames, EFeatures.Men);

            Debug.Assert(filteredFrames.Count == 2);
            Debug.Assert(filteredFrames[0].ID == frames[0].ID);
            Debug.Assert(filteredFrames[1].ID == frames[5].ID);

            filteredFrames = FilterEngine.FilterFrames(frames, EFeatures.Men | EFeatures.Red | EFeatures.Aviator);
            Debug.Assert(filteredFrames.Count == 4);
            Debug.Assert(filteredFrames[0].ID == frames[0].ID);
            Debug.Assert(filteredFrames[1].ID == frames[2].ID);
            Debug.Assert(filteredFrames[2].ID == frames[4].ID);
            Debug.Assert(filteredFrames[3].ID == frames[5].ID);

            List<Frame> filteredOutFrames = FilterEngine.FilterOutFrames(frames, EFeatures.Aviator | EFeatures.Women | EFeatures.Red);
            Debug.Assert(filteredOutFrames.Count == 3);
            Debug.Assert(filteredOutFrames[0].ID == frames[3].ID);
            Debug.Assert(filteredOutFrames[1].ID == frames[5].ID);
            Debug.Assert(filteredOutFrames[2].ID == frames[6].ID);

            List<Frame> frames2 = new List<Frame>
            {
                new Frame(9, "Kam Dhillon"),
                frames[0],
                frames[3],
                new Frame(10, "Dior"),
                new Frame(11, "Calvin Klein"),
                frames[5],
                frames[6],
                new Frame(12, "Lacoste"),
            };

            List<Frame> intersect = FilterEngine.Intersect(frames, frames2);

            Debug.Assert(intersect.Count == 4);
            Debug.Assert(intersect.FirstOrDefault(i => i.ID == frames[0].ID) != null);
            Debug.Assert(intersect.FirstOrDefault(i => i.ID == frames[3].ID) != null);
            Debug.Assert(intersect.FirstOrDefault(i => i.ID == frames[5].ID) != null);
            Debug.Assert(intersect.FirstOrDefault(i => i.ID == frames[6].ID) != null);

            List<int> sortKeys = FilterEngine.GetSortKeys(frames, new List<EFeatures> { EFeatures.Aviator, EFeatures.Men, EFeatures.Rectangle, EFeatures.Red });
            Debug.Assert(sortKeys.Count == frames.Count);

            List<Frame> sortedFrames = sort(sortKeys, frames);

            Debug.Assert(sortedFrames[0].ID == frames[2].ID);
            Debug.Assert(sortedFrames[1].ID == frames[0].ID);
            Debug.Assert(sortedFrames[2].ID == frames[5].ID);
            Debug.Assert(sortedFrames[3].ID == frames[4].ID);
            Debug.Assert(sortedFrames[4].ID == frames[1].ID || sortedFrames[4].ID == frames[3].ID || sortedFrames[4].ID == frames[6].ID);
            Debug.Assert(sortedFrames[5].ID == frames[1].ID || sortedFrames[5].ID == frames[3].ID || sortedFrames[5].ID == frames[6].ID);
            Debug.Assert(sortedFrames[6].ID == frames[1].ID || sortedFrames[6].ID == frames[3].ID || sortedFrames[6].ID == frames[6].ID);

            sortKeys = FilterEngine.GetSortKeys(frames, new List<EFeatures> { EFeatures.Rectangle, EFeatures.Black, EFeatures.Women });
            Debug.Assert(sortKeys.Count == frames.Count);

            sortedFrames = sort(sortKeys, frames);

            Debug.Assert(sortedFrames[0].ID == frames[0].ID);
            Debug.Assert(sortedFrames[1].ID == frames[1].ID);
            Debug.Assert(sortedFrames[2].ID == frames[2].ID || sortedFrames[2].ID == frames[5].ID || sortedFrames[2].ID == frames[6].ID);
            Debug.Assert(sortedFrames[3].ID == frames[2].ID || sortedFrames[3].ID == frames[5].ID || sortedFrames[3].ID == frames[6].ID);
            Debug.Assert(sortedFrames[4].ID == frames[2].ID || sortedFrames[4].ID == frames[5].ID || sortedFrames[4].ID == frames[6].ID);
            Debug.Assert(sortedFrames[5].ID == frames[3].ID || sortedFrames[5].ID == frames[4].ID);
            Debug.Assert(sortedFrames[6].ID == frames[3].ID || sortedFrames[6].ID == frames[4].ID);
        }

        private static List<Frame> sort(List<int> sortKeys, List<Frame> frames)
        {
            List<Tuple<int, Frame>> tuples = new List<Tuple<int, Frame>>();
            for (int i = 0; i < sortKeys.Count; i++)
            {
                tuples.Add(new Tuple<int, Frame>(sortKeys[i], frames[i]));
            }

            tuples.Sort((t1, t2) =>
            {
                return t2.Item1 - t1.Item1;
            });

            return tuples.Select(t => t.Item2).ToList();
        }
    }
}
```