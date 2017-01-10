if re.search(r"v"):
    print("That string had at least one 'v' in it!")
else:
    print("No 'v' found!")

if re.search(r"ss"):
    print("That string had at least one 'ss's in it!")
else:
    print("No 'ss' found!")

if re.search(r"a.*a"):
   print("That string had at least two 'a's in it!")
else:
   print("No more than one 'a' found!")



9. [a-z]{2}
