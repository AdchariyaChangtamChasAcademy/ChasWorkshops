using System.Text.Json.Serialization;

namespace WS_AsyncPaging.DTOs
{
    public class PaginationDTOs
    {
        // 1. Metadatan: Beskriver "vart vi är" i listan
        public record PaginationMeta
        {
            public int Page { get; init; }
            public int PageSize { get; init; }
            public int TotalPages { get; init; }
            public int TotalCount { get; init; }
            public bool HasNext { get; init; }
            public bool HasPrevious { get; init; }

            public PaginationMeta() { } // Parameterless constructor for JSON

            public PaginationMeta(int page, int pageSize, int totalPages, int totalCount, bool hasNext, bool hasPrevious)
            {
                Page = page;
                PageSize = pageSize;
                TotalPages = totalPages;
                TotalCount = totalCount;
                HasNext = hasNext;
                HasPrevious = hasPrevious;
            }
        }

        // 2. Kuvertet: Håller både metadatan och själva listan (Generisk <T> så vi kan återanvända den!)
        public record PagedResponse<T>(
            IEnumerable<T> Data,
            PaginationMeta Pagination
        );
    }
}
