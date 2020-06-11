# String Parser Challenge

## The Problem
Write C# code with unit-tests to process a collection of string values which are passed to a method
which returns a collection of processed strings. The input strings may be any length and can contain
any character. Output strings must not be null or empty string, should be truncated to max length of
15 chars, and contiguous duplicate characters in the same case should be reduced to a single
character in the same case. Dollar sign ($) should be replaced with a pound sign (£), and underscores
(_) and number 4 should be removed. Code should be test-driven, efficient, re-usable and loosely
coupled. The returned collection must not be null.

**Example input string: AAAc91%cWwWkLq$1ci3_848v3d__K**

## Acceptance Criteria
- Can submit any number of strings of any length and any character;
- Dollar signs ($) should be replaced by Pound Signs (£);
- Underscores (_) and number four (4) should be removed;
- Contiguous case-sensitive character duplicates should be removed;
- Output strings should not be null or empty;
- Output strings should be truncated at 15 characters;
- Output should not be null.

## Definition of Done
- All Acceptance Criteria have been met;
- Code performance was taken into consideration;
- Implementation is loosely coupled (Ready for introducing IoC);
- Code is functionally covered in unit tests, written in TDD;
- Acceptance test is present against the example input provided;
- All best practices were fully considered;
- All tests are passing.

## Assumptions
- Input collection of strings should not be null.
- Since it is unclear which order of parsings should take, there might be a corner case where removed characters might put duplicates contiguously. E.g. 848 in the example input string, when 4 is removed.
It doesn't happen with the input sample due to the truncation. However, the code is not prepared for it yet.

## Remarks
- All commits were done with high granularity to showcase the TDD process.
- ParserAcceptanceTests.cs should be in a proper Acceptance Tests Project. It was left together with the unit tests for the sake of simplicity.
