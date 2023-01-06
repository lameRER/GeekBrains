class PhoneBook(object):
    items = []

    def __init__(self, lastName, firstName, parthName, phone):
        self.lastName = lastName
        self.firstName = firstName
        self.parthName = parthName
        self.phone = phone
        self.items.append(self)
