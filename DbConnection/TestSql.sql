CREATE TABLE test_table (
daytime timestamp
,test_no integer
,test_name varchar
,value integer
,comment varchar
,PRIMARY KEY(daytime, test_no)
);

-- commit;

select * from public.test_table;

INSERT INTO test_table 
(daytime ,test_no ,test_name ,value ,comment )
VALUES
('2025-01-01 12:00:00', 10, 'C#connection010', 100, 'test010')
,('2025-01-01 13:00:00', 15, 'C#connection015', 110, 'test015')
;

-- commit;
