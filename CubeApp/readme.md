#### 题目1-物业公司数据表操作
1. Get a list of tenants who are renting more than one apartment. 
```
SELECT att.`TenantID`,tat.`TenantName`
FROM AptTenants att 
INNER JOIN Tenants tat ON att.`TenantID`=tat.`TenantID`
GROUP BY att.`TenantID`,tat.`TenantName`
HAVING COUNT(*) > 1;
```
2. Get a list of all buildings and the number of open requests (Requests in which status equals 'Open'). 
```
SELECT bd.`BuildingID`,bd.`BuildingName`,bd.`ComplexID`,bd.`Address`,
CASE WHEN t.reqcount IS NULL THEN 0 ELSE t.reqcount END reqcount
FROM Buildings bd 
LEFT JOIN
(SELECT apt.`BuildingID`,COUNT(*) reqcount
FROM Apartments apt
LEFT JOIN Requests rq ON apt.`AptID`=rq.`AptID`
WHERE rq.`Status`='Open'
GROUP BY apt.`BuildingID`) t
ON bd.`BuildingID`=t.`BuildingID`
```
3. Building #3 in Complex #1 is undergoing a major renovation. Implement a query to close all requests from apartments in this building.  
```
UPDATE requests
SET `Status`='Close'
WHERE AptID IN (
SELECT apt.AptID FROM `Apartments` apt 
INNER JOIN Buildings bd ON apt.BuildingID=bd.BuildingID
INNER JOIN complexes cmp ON bd.`ComplexID`=cmp.`ComplexID`
WHERE cmp.`complexName`='#1' AND bd.`BuildingName`='#3'
)
```

#### 题目2-学校数据库操作
1. 给学校设计一个数据库，库里存着每个学生在每个课程的成绩（均是百分制），可以回想下你大学的时候

   1.1 学生表(Student)

   | 字段        | 类型        | 主键 | 描述 |
   | ----------- | ----------- | ---- | ---- |
   | StudentId   | int         | 是   |      |
   | StudentName | varchar(24) | 否   |      |

   1.2 课程(Course)

   | 字段       | 类型        | 主键 | 描述 |
   | ---------- | ----------- | ---- | ---- |
   | CourseId   | int         | 是   |      |
   | CourseName | varchar(48) | 否   |      |

   1.3 成绩表(StudentCourse)

   | 字段      | 类型   | 主键 | 描述 |
   | --------- | ------ | ---- | ---- |
   | Id        | int    | 是   |      |
   | StudentId | int    |      |      |
   | CourseId  | int    |      |      |
   | Score     | double |      |      |

   

2. 写一个查询，找出所有平均分在前10%的学生，并且按照他们的成绩从高到低排名。注意：每个学生参加的课程的数量可能不同，平均分指的是学生成绩总分/参加课程的数量
```
SELECT CASE WHEN CAST(COUNT(DISTINCT(StudentId)) * 0.1 AS SIGNED)=0 THEN 1
ELSE CAST(COUNT(DISTINCT(StudentId)) * 0.1 AS SIGNED) END  INTO @cnt FROM StudentCourse;
PREPARE stmt FROM 
'select sc.StudentId,sum(sc.Score) / COUNT(*) as AvgScore
from StudentCourse sc 
group by sc.StudentId
order by AvgScore desc
limit ?;';
EXECUTE stmt USING @cnt;
DROP PREPARE stmt;
```