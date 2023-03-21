using Entities.DataTransferObjects.Author;
using Entities.DataTransferObjects.Publisher;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Mapster;

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
    }
}
