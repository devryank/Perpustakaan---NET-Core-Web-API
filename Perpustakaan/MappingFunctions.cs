using Entities.DataTransferObjects.Author;
using Entities.DataTransferObjects.Book;
using Entities.DataTransferObjects.Publisher;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Mapster;
using System.Net.NetworkInformation;

namespace Perpustakaan
{
    public static class MappingFunctions
    {
        public static UserDto UserById(User user)
        {
            var userDto = user.Adapt<UserDto>();
            return userDto;
        }

        public static User ReplaceUser(UserForUpdateDto userDto, User userEntity)
        {
            var user = userDto.Adapt(userEntity);
            return user;
        }

        public static User CreateUser(UserForCreationDto userDto)
        {
            var user = userDto.Adapt<User>();
            return user;
        }

        public static AuthorDto GetAuthorById(Author author)
        {
            var authorDto = author.Adapt<AuthorDto>();
            return authorDto;
        }
        public static AuthorWithBooksDto GetAuthorWithBooks(Author author)
        {
            var authorDto = author.Adapt<AuthorWithBooksDto>();
            return authorDto;
        }

        public static Author CreateAuthor(AuthorForCreationDto authorDto)
        {
            var author = authorDto.Adapt<Author>();
            return author;
        }

        public static Author ReplaceAuthor(AuthorForUpdateDto authorDto, Author authorEntity)
        {
            var author = authorDto.Adapt(authorEntity);
            return author;
        }

        public static PublisherDto GetPublisherById(Publisher publisher)
        {
            var publisherDto = publisher.Adapt<PublisherDto>();
            return publisherDto;
        }

        //public static IQueryable<PublisherWithBooksDto> GetPublisherWithBooks(Publisher publisher)
        //{
        //    var publisherDto = publisher.AsQueryable();
        //    publisherDto = publisher.Adapt<PublisherWithBooksDto>();
        //    return publisherDto;
        //}
        public static PublisherWithBooksDto GetPublisherWithBooks(Publisher publisher)
        {
            var publisherDto = publisher.Adapt<PublisherWithBooksDto>();
            return publisherDto;
        }

        public static Publisher CreatePublisher(PublisherForCreationDto publisherDto)
        {
            var publisher = publisherDto.Adapt<Publisher>();
            return publisher;
        }

        public static Publisher ReplacePublisher(PublisherForUpdateDto publisherDto, Publisher publisherEntity)
        {
            var publisher = publisherDto.Adapt(publisherEntity);
            return publisher;
        }

        public static BookDto GetBookById(Book book)
        {
            var bookDto = book.Adapt<BookDto>();
            return bookDto;
        }

        public static Book AdaptWithItself(Book book)
        {
            var bookMap = book.Adapt<BookDto>().Adapt<Book>();
            return bookMap;
        }

        public static BookWithRelationDto GetBookWithRelationById(Book book)
        {
            var bookDto = book.Adapt<BookWithRelationDto>();
            return bookDto;
        }

        public static Book CreateBook(BookForCreationDto bookDto)
        {
            var book = bookDto.Adapt<Book>();
            return book;
        }

        public static Book ReplaceBook(BookForUpdateDto bookDto, Book bookEntity)
        {
            var book = bookDto.Adapt(bookEntity);
            return book;
        }

        public static BookDto ReplaceBookWithDto(BookForUpdateDto bookUpdateDto, BookDto bookDto)
        {
            var book = bookUpdateDto.Adapt(bookDto);
            return book;
        }
    }
}
