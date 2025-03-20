## 구현 목록
### 1.  주술
 주술 생성과 합성 시스템 구현. 주술 생성마다 주술 생성 비용이 1골드 증가.  
 주술 2종 구현: 특급 주술대전의 땅, 물 주술을 참고해 주술 스킬 세부 구현.  
  (미구현)  주술 이펙트 미구현. 시간 부족으로 인해 현재 주술들은 몬스터와 보스의 위치를 기반으로 발동   
스킬 사용 여부와 몬스터 히트 판정 여부가 제대로 작동하는 것을 Console의 로그로 확인 가능. (모든 영상에 콘솔 로그 포함)  
(물 일반 스킬과 같이 스킬 오브젝트가 몬스터에게 직접 맞아야 하는 스킬은 플레이어와 몬스터의 거리를 사용해 히트판정)  
 플레이어 주술 생성 / 합성 UI 구현  
특급 주술대전과 동일하게 주술의 쿨타임을 (기본쿨타임)/(보유주술 갯수) 로 구현.  
  
### 2. 신수 
신수 2종 구현  
신수 1: 50초마다 70코인을 수급합니다. 소환에 땅 전설, 물 희귀, 물 영웅 주술 필요. (특급 주술대전의 "스크로우 영감 Lv1"을 기반으로 "신수 1" 구현.)  
신수 2: 40초마다 플레이어의 체력을 15% 회복합니다. 소환에 물 전설, 땅 희귀, 땅 영웅 주술 필요. (특급 주술대전의 "대사제 복실이 Lv1"을 기반으로"신수 2" 구현)  
(미구현) 특급 주술대전의 신수 소환 후 인게임 내 이동 기능은 구현 x (시간 부족)  
  
### 3. 강화
강화 로직 및 UI 구현 (소환 확률 강화, 물 주술 강화, 땅 주술 강화, 신수 강화)  
특급 주술 대전의 정확한 강화 수치를 몰라 임의의 수치로 구현. 구현된 게임에서는 여러 단계가 아닌 한번만 강화 가능하도록 구현.  
1. 확률 강화: 특급 주술대전의 확률 강화 레벨 8과 비슷하게 구현 (전설, 선조, 천벌 소환 확률 동일)  
2. 땅 주술 강화: 땅 주술의 데미지가 2배로 증가  
3. 물 주술 강화: 물 주술의 데미지가 2배로 증가  
4. 신수 강화: 신수 스킬의 효과가 2배로 증가.  
  
### 4. 채굴:
특급 주술대전과 동일하게 채굴 시스템 구현 (1 영혼을 소비해 영웅 주술 획득, 3 영혼을 소비해 전설 주술 획득, 7영혼을 소비해 선조 주술 획득)  
  
### 5. 몬스터 / 보스:
각 웨이브마다 처음 1초, 마지막 1초의 시간을 제외하고 0.5초의 간격으로 일반 몬스터 소환 (웨이브 3개마다 각 웨이브의 시간 2초 연장).  
10번째 웨이브마다 보스 소환.  
웨이브마다 일반 몬스터, 보스의 체력 증가.  
몬스터 토벌 시, 일반 몬스터는 +3 골드, 보스는 +2 영혼 보상 드랍.  
모든 플레이어가 보스 토벌 시, 바로 다음 스테이지로 이동.  
  
### 6. 현상금:
특급 주술대전의 1,2번째 현상금과 동일한 체력과 보상으로 2개의 현상금 보스 구현.  
보스와 유사한 로직과 프리팹을 사용하도록 현상금 구현.  
  
### 7. Bot (상대 플레이어들 3명)  
골드가 충족되면 주술 소환  
합성 가능한 주술이 있다면 주술 합성  
신수 소환이 가능하면 신수 소환  
  
## 버그 목록 (발견했지만 시간 상 수정하지 못한 버그들)  
1.  몹과 보스가 공격 받았을 시, 체력바가 체력 비례로 나오는 것이 아닌, 0으로 보이는 현상 (UI 문제. 로직 상으로는 문제 없음).  
2. 신수 메뉴에서 신수 버튼 클릭 전에는 필요한 주술 수급량이 나타나지 않는 UI 버그. (클릭 전에는 언제나 0/3으로 표기. 클릭하면 정상 업데이트)  
